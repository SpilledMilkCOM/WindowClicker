using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WindowClicker
{
	/// <summary>
	/// Borrowed this code from here:  https://stackoverflow.com/questions/10355286/programmatically-mouse-click-in-another-window
	/// Other reference: https://github.com/michaelnoonan/inputsimulator/blob/master/WindowsInput/InputBuilder.cs
	/// </summary>
	public class ClickOnPointTool
	{
		[Flags]
		enum MouseEventFlags : uint
		{
			MOUSEEVENTF_MOVE = 0x0001,
			MOUSEEVENTF_LEFTDOWN = 0x0002,
			MOUSEEVENTF_LEFTUP = 0x0004,
			MOUSEEVENTF_RIGHTDOWN = 0x0008,
			MOUSEEVENTF_RIGHTUP = 0x0010,
			MOUSEEVENTF_MIDDLEDOWN = 0x0020,
			MOUSEEVENTF_MIDDLEUP = 0x0040,
			MOUSEEVENTF_XDOWN = 0x0080,
			MOUSEEVENTF_XUP = 0x0100,
			MOUSEEVENTF_WHEEL = 0x0800,
			MOUSEEVENTF_VIRTUALDESK = 0x4000,
			MOUSEEVENTF_ABSOLUTE = 0x8000
		}

		enum SendInputEventType : int
		{
			InputMouse,
			InputKeyboard,
			InputHardware
		}

		[DllImport("user32.dll")]
		static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

		[DllImport("user32.dll")]
		static extern bool SetCursorPos(int X, int Y);

#pragma warning disable 649
		internal struct INPUT
		{
			public UInt32 Type;
			public MOUSEKEYBDHARDWAREINPUT Data;
		}

		[StructLayout(LayoutKind.Explicit)]
		internal struct MOUSEKEYBDHARDWAREINPUT
		{
			[FieldOffset(0)]
			public MOUSEINPUT Mouse;
		}

		internal struct MOUSEINPUT
		{
			public Int32 X;
			public Int32 Y;
			public UInt32 MouseData;
			public UInt32 Flags;
			public UInt32 Time;
			public IntPtr ExtraInfo;
		}

#pragma warning restore 649

		public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint, bool savePosition = true, int numberOfClicks = 1)
		{
			var oldPos = Cursor.Position;
			var delay = true;

			// get screen coordinates
			//ClientToScreen(wndHandle, ref clientPoint);

			// set cursor on coords, and press mouse
			Cursor.Position = new Point(clientPoint.X, clientPoint.Y);
			//SetCursorPos(clientPoint.X, clientPoint.Y);

			//if (delay)
			//{
			//	Thread.Sleep(50);
			//}

			var inputMouseDown = new INPUT();
			inputMouseDown.Type = (uint)SendInputEventType.InputMouse;
			inputMouseDown.Data.Mouse.Flags = (uint)(MouseEventFlags.MOUSEEVENTF_LEFTDOWN | MouseEventFlags.MOUSEEVENTF_ABSOLUTE);
			inputMouseDown.Data.Mouse.X = clientPoint.X;
			inputMouseDown.Data.Mouse.Y = clientPoint.Y;

			var inputMouseUp = new INPUT();
			inputMouseUp.Type = (uint)SendInputEventType.InputMouse;
			inputMouseUp.Data.Mouse.Flags = (uint)(MouseEventFlags.MOUSEEVENTF_LEFTUP | MouseEventFlags.MOUSEEVENTF_ABSOLUTE);
			inputMouseUp.Data.Mouse.X = clientPoint.X;
			inputMouseUp.Data.Mouse.Y = clientPoint.Y;

			var inputs = new INPUT[] { inputMouseDown, inputMouseUp };

			if (numberOfClicks > 1)
			{
				for (int i = 0; i < numberOfClicks; i++)
				{
					SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
				}
			}
			else
			{
				if (delay)
				{
					var mouseInput = new INPUT();
					mouseInput.Type = (uint)SendInputEventType.InputMouse;
					mouseInput.Data.Mouse.Flags = (uint)(MouseEventFlags.MOUSEEVENTF_MOVE | MouseEventFlags.MOUSEEVENTF_ABSOLUTE);
					mouseInput.Data.Mouse.X = clientPoint.X;
					mouseInput.Data.Mouse.Y = clientPoint.Y;

					var input = new INPUT[] { mouseInput };

					// Move mouse.
					SendInput((uint)inputs.Length, input, Marshal.SizeOf(typeof(INPUT)));

					Thread.Sleep(50);

					// Mouse down

					mouseInput.Data.Mouse.Flags = (uint)(MouseEventFlags.MOUSEEVENTF_LEFTDOWN);
					mouseInput.Data.Mouse.X = 0;
					mouseInput.Data.Mouse.Y = 0;

					SendInput((uint)inputs.Length, input, Marshal.SizeOf(typeof(INPUT)));

					Thread.Sleep(50);

					// Mouse up

					mouseInput.Data.Mouse.Flags = (uint)(MouseEventFlags.MOUSEEVENTF_LEFTUP);

					SendInput((uint)inputs.Length, input, Marshal.SizeOf(typeof(INPUT)));
				}
				else
				{
					SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
				}
			}

			if (savePosition)
			{
				// return mouse to original position
				Cursor.Position = oldPos;
			}
		}

		public static void VerticalWheel(IntPtr wndHandle, Point clientPoint, UInt32 scrollAmount = 1)
		{
			var oldPos = Cursor.Position;

			// Set cursor on coords
			Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

			var inputVerticalScroll = new INPUT();

			inputVerticalScroll.Type = 0;                        // input type mouse
			inputVerticalScroll.Data.Mouse.Flags = (uint)MouseEventFlags.MOUSEEVENTF_WHEEL; ;       // Vertical Wheel
			inputVerticalScroll.Data.Mouse.MouseData = scrollAmount;

			var inputs = new INPUT[] { inputVerticalScroll };

			SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

			// Return mouse to original position
			Cursor.Position = oldPos;
		}
	}
}