using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WpfUi
{
    public static class BitmapFiltersAPI
    {
        [DllImport(@"..\..\..\..\Debug\CodeCpp.dll",
               CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateBitmapFilter();

        [DllImport(@"..\..\..\..\Debug\CodeCpp.dll",
               CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateBitmapFilterNegative();

        [DllImport(@"..\..\..\..\Debug\CodeCpp.dll",
               CallingConvention = CallingConvention.Cdecl)]

        public static extern IntPtr CreateBitmapFilterRed();

        [DllImport(@"..\..\..\..\Debug\CodeCpp.dll",
               CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPixels(IntPtr ptrBmpFilter, byte[] pixels, long count);

        [DllImport(@"..\..\..\..\Debug\CodeCpp.dll",
               CallingConvention = CallingConvention.Cdecl)]
        public static extern long GetLength(IntPtr ptrBmpFilter);

        [DllImport(@"..\..\..\..\Debug\CodeCpp.dll",
               CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetPixels(IntPtr ptrBmpFilter, ref int length);

        [DllImport(@"..\..\..\..\Debug\CodeCpp.dll",
               CallingConvention = CallingConvention.Cdecl)]
        public static extern void Update(IntPtr ptrBmpFilter);

        [DllImport(@"..\..\..\..\Debug\CodeCpp.dll",
               CallingConvention = CallingConvention.Cdecl)]
        public static extern void Dispose(IntPtr ptrBmpFilter);
    }
}
