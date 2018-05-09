// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.


using System;

namespace SoulWorker.Framework.Misc
{
    public static class Extensions
    {
        public static byte[] Combine(this byte[] data, params byte[][] pData)
        {
            var combined = data;

            foreach (var arr in pData)
            {
                var currentSize = combined.Length;

                Array.Resize(ref combined, currentSize + arr.Length);

                Buffer.BlockCopy(arr, 0, combined, currentSize, arr.Length);
            }

            return combined;
        }
    }
}
