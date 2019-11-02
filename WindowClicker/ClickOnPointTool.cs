﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowClicker
{
	/// <summary>
	/// Borrowed this code from here:  https://stackoverflow.com/questions/10355286/programmatically-mouse-click-in-another-window
	/// Other reference: https://github.com/michaelnoonan/inputsimulator/blob/master/WindowsInput/InputBuilder.cs
	/// </summary>
	public class ClickOnPointTool
	{
		[DllImport("user32.dll")]
		static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

		[DllImport("user32.dll")]
		internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

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

		public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint, int numberOfClicks = 1)
		{
			var oldPos = Cursor.Position;

			// get screen coordinates
			//ClientToScreen(wndHandle, ref clientPoint);

			// set cursor on coords, and press mouse
			Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

			var inputMouseDown = new INPUT();
			inputMouseDown.Type = 0;                        // input type mouse
			inputMouseDown.Data.Mouse.Flags = 0x0002;       // left button down

			var inputMouseUp = new INPUT();
			inputMouseUp.Type = 0;                          // input type mouse
			inputMouseUp.Data.Mouse.Flags = 0x0004;         // left button up

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
				SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
			}

			// return mouse to original position
			Cursor.Position = oldPos;
		}

		public static void VerticalWheel(IntPtr wndHandle, Point clientPoint, UInt32 scrollAmount = 1)
		{
			var oldPos = Cursor.Position;

			// Set cursor on coords
			Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

			var inputVerticalScroll = new INPUT();

			inputVerticalScroll.Type = 0;                        // input type mouse
			inputVerticalScroll.Data.Mouse.Flags = 0x0800;       // Vertical Wheel
			inputVerticalScroll.Data.Mouse.MouseData = scrollAmount;

			var inputs = new INPUT[] { inputVerticalScroll };

			SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

			// Return mouse to original position
			Cursor.Position = oldPos;
		}
	}
}