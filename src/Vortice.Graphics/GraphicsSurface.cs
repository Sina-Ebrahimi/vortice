// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System;
using System.Drawing;

namespace Vortice.Graphics
{
    public abstract class GraphicsSurface : IDisposable
    {
        protected GraphicsSurface(SurfaceSource source)
        {
            Source = source;
        }

        public SurfaceSource Source { get; }

        public Size Size { get; protected set; }

        /// <summary>
        /// Finalizes an instance of the <see cref="GraphicsSurface" /> class.
        /// </summary>
        ~GraphicsSurface() => Dispose(disposing: false);

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc cref="Dispose()" />
        /// <param name="disposing"><c>true</c> if the method was called from <see cref="Dispose()" />; otherwise, <c>false</c>.</param>
        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
