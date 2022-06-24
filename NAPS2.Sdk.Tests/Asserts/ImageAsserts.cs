﻿using Xunit;

namespace NAPS2.Sdk.Tests.Asserts;

public static class ImageAsserts
{
    // JPEG artifacts seem to consistently create a RMSE of about 2.5.
    // TODO: Use PNG or some other way to do a precise comparison.
    public const double GENERAL_RMSE_THRESHOLD = 3.5;

    public const double NULL_RMSE_THRESHOLD = 0.5;

    private const double RESOLUTION_THRESHOLD = 0.02;

    public static unsafe void Similar(IMemoryImage first, IMemoryImage second, double rmseThreshold)
    {
        Assert.Equal(first.Width, second.Width);
        Assert.Equal(first.Height, second.Height);
        Assert.Equal(first.PixelFormat, second.PixelFormat);
        Assert.InRange(second.HorizontalResolution,
            first.HorizontalResolution - RESOLUTION_THRESHOLD,
            first.HorizontalResolution + RESOLUTION_THRESHOLD);
        Assert.InRange(second.VerticalResolution,
            first.VerticalResolution - RESOLUTION_THRESHOLD,
            first.VerticalResolution + RESOLUTION_THRESHOLD);

        var lock1 = first.Lock(LockMode.ReadOnly, out var scan01, out var stride1);
        var lock2 = second.Lock(LockMode.ReadOnly, out var scan02, out var stride2);
        try
        {
            if (first.PixelFormat != ImagePixelFormat.RGB24 && first.PixelFormat != ImagePixelFormat.ARGB32 ||
                first.PixelFormat != second.PixelFormat)
            {
                throw new InvalidOperationException("Unsupported pixel format");
            }
            int width = first.Width;
            int height = first.Height;
            int bytesPerPixel = first.PixelFormat == ImagePixelFormat.ARGB32 ? 4 : 3;
            long total = 0;
            long div = width * height * 3;
            byte* data1 = (byte*) scan01;
            byte* data2 = (byte*) scan02;
            for (int y = 0; y < height; y++)
            {
                byte* row1 = data1 + stride1 * y;
                byte* row2 = data2 + stride2 * y;
                for (int x = 0; x < width; x++)
                {
                    byte* pixel1 = row1 + x * bytesPerPixel;
                    byte* pixel2 = row2 + x * bytesPerPixel;

                    byte r1 = *pixel1;
                    byte g1 = *(pixel1 + 1);
                    byte b1 = *(pixel1 + 2);

                    byte r2 = *pixel2;
                    byte g2 = *(pixel2 + 1);
                    byte b2 = *(pixel2 + 2);

                    total += (r1 - r2) * (r1 - r2) + (g1 - g2) * (g1 - g2) + (b1 - b2) * (b1 - b2);

                    if (bytesPerPixel == 4)
                    {
                        byte a1 = *(pixel1 + 3);
                        byte a2 = *(pixel2 + 3);
                        total += (a1 - a2) * (a1 - a2);
                    }
                }
            }

            double rmse = Math.Sqrt(total / (double) div);
            Assert.True(rmse <= rmseThreshold, $"RMSE was {rmse}, expected <= {rmseThreshold}");
        }
        finally
        {
            first.Unlock(lock1);
            second.Unlock(lock2);
        }
    }
}