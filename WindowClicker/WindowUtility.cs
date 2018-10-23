using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowClicker
{
	/// <summary>
	/// Not really using this class at the moment.
	/// </summary>
	class WindowUtility
	{
		public void CloseWindow(string processName)
		{
			Process[] processes = Process.GetProcessesByName(processName);

			if (processes.Length > 0)
			{
				foreach (var process in processes)
				{
					IDictionary<IntPtr, string> windows = List_Windows_By_PID(process.Id);

					foreach (KeyValuePair<IntPtr, string> pair in windows)
					{
						var placement = new WINDOWPLACEMENT();

						GetWindowPlacement(pair.Key, ref placement);

						if (placement.showCmd == SW_SHOWMINIMIZED)
						{
							//if minimized, show maximized
							ShowWindowAsync(pair.Key, SW_SHOWMAXIMIZED);
						}
						else
						{
							//default to minimize
							ShowWindowAsync(pair.Key, SW_SHOWMINIMIZED);
						}
					}
				}
			}
		}

		private const int SW_SHOWNORMAL = 1;
		private const int SW_SHOWMINIMIZED = 2;
		private const int SW_SHOWMAXIMIZED = 3;

		private struct WINDOWPLACEMENT
		{
			public int length;
			public int flags;
			public int showCmd;
			public Point ptMinPosition;
			public Point ptMaxPosition;
			public Rectangle rcNormalPosition;
		}

		private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

		[DllImport("user32.dll")]
		private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		[DllImport("user32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private extern static bool EnumThreadWindows(int threadId, EnumWindowsProc callback, IntPtr lParam);

		[DllImport("user32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

		[DllImport("USER32.DLL")]
		private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

		[DllImport("USER32.DLL")]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport("USER32.DLL")]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		[DllImport("USER32.DLL")]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		[DllImport("USER32.DLL")]
		private static extern IntPtr GetShellWindow();

		[DllImport("USER32.DLL")]
		private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

		public static IDictionary<IntPtr, string> List_Windows_By_PID(int processID)
		{
			IntPtr hShellWindow = GetShellWindow();
			Dictionary<IntPtr, string> dictWindows = new Dictionary<IntPtr, string>();

			EnumWindows(delegate (IntPtr hWnd, int lParam)
			{
				//ignore the shell window
				if (hWnd == hShellWindow)
				{
					return true;
				}

				//ignore non-visible windows
				if (!IsWindowVisible(hWnd))
				{
					return true;
				}

				//ignore windows with no text
				int length = GetWindowTextLength(hWnd);
				if (length == 0)
				{
					return true;
				}

				uint windowPid;
				GetWindowThreadProcessId(hWnd, out windowPid);

				//ignore windows from a different process
				if (windowPid != processID)
				{
					return true;
				}

				StringBuilder stringBuilder = new StringBuilder(length);
				GetWindowText(hWnd, stringBuilder, length + 1);
				dictWindows.Add(hWnd, stringBuilder.ToString());

				return true;

			}, 0);

			return dictWindows;
		}
	}
}