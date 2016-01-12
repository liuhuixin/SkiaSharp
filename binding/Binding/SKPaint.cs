﻿//
// Bindings for SKPaint
//
// Author:
//   Miguel de Icaza
//
// Copyright 2015 Xamarin Inc
//
using System;

namespace SkiaSharp
{
	public class SKPaint : IDisposable 
	{
		internal IntPtr handle;

		public SKPaint ()
		{
			handle = SkiaApi.sk_paint_new ();
		}

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		protected virtual void Dispose (bool disposing)
		{
			if (handle != IntPtr.Zero) {
				SkiaApi.sk_paint_delete (handle);
				handle = IntPtr.Zero;
			}
		}

		~SKPaint()
		{
			Dispose (false);
		}

		public bool IsAntialias {
			get {
				return SkiaApi.sk_paint_is_antialias (handle);
			}
			set {
				SkiaApi.sk_paint_set_antialias (handle, value);
			}
		}

		public bool IsStroke {
			get {
				return SkiaApi.sk_paint_is_stroke (handle);
			}
			set {
				SkiaApi.sk_paint_set_stroke (handle, value);
			}
		}

		public SKColor Color {
			get {
				return SkiaApi.sk_paint_get_color (handle);
			}
			set {
				SkiaApi.sk_paint_set_color (handle, value);
			}
		}
		
		public float StrokeWidth {
			get {
				return SkiaApi.sk_paint_get_stroke_width (handle);
			}
			set {
				SkiaApi.sk_paint_set_stroke_width (handle, value);
			}
		}

		public float StrokeMiter {
			get {
				return SkiaApi.sk_paint_get_stroke_miter (handle);
			}
			set {
				SkiaApi.sk_paint_set_stroke_miter (handle, value);
			}
		}

		public SKStrokeCap StrokeCap {
			get {
				return SkiaApi.sk_paint_get_stroke_cap (handle);
			}
			set {
				SkiaApi.sk_paint_set_stroke_cap (handle, value);
			}
		}

		public SKStrokeJoin StrokeJoin {
			get {
				return SkiaApi.sk_paint_get_stroke_join (handle);
			}
			set {
				SkiaApi.sk_paint_set_stroke_join (handle, value);
			}
		}

		// C API does not surface getter, so emulate it 
		SKShader shader = null;
		public SKShader Shader {
			get {
				return shader;
			}
			set {
				shader = value;
				SkiaApi.sk_paint_set_shader (handle, shader == null ? IntPtr.Zero : shader.handle);
			}
		}

		// C API does not surface getter, so emulate it 
		SKMaskFilter filter = null;
		public SKMaskFilter MaskFilter {
			get {
				return filter;
			}
			set {
				filter = value;
				SkiaApi.sk_paint_set_maskfilter (handle, filter == null ? IntPtr.Zero : filter.handle);
			}
		}

		SKXferMode mode = SKXferMode.SrcOver;
		public SKXferMode XferMode {
			get {
				return mode;
			}
			set {
				mode = value;
				SkiaApi.sk_paint_set_xfermode_mode (handle, mode);
			}
		}

		public SKTypeface Typeface {
			get {
				return new SKTypeface (SkiaApi.sk_paint_get_typeface (handle), owns: false);
			}
			set {
				SkiaApi.sk_paint_set_typeface (handle, value == null ? IntPtr.Zero : value.handle);
			}
		}

		public float TextSize {
			get {
				return SkiaApi.sk_paint_get_textsize (handle);
			}
			set {
				SkiaApi.sk_paint_set_textsize (handle, value);
			}
		}

		public SKTextAlign TextAlign {
			get {
				return SkiaApi.sk_paint_get_text_align (handle);
			}
			set {
				SkiaApi.sk_paint_set_text_align (handle, value);
			}
		}

		public SKTextEncoding TextEncoding {
			get {
				return SkiaApi.sk_paint_get_text_encoding (handle);
			}
			set {
				SkiaApi.sk_paint_set_text_encoding (handle, value);
			}
		}

		public float TextScaleX {
			get {
				return SkiaApi.sk_paint_get_text_scale_x (handle);
			}
			set {
				SkiaApi.sk_paint_set_text_scale_x (handle, value);
			}
		}

		public float TextSkewX {
			get {
				return SkiaApi.sk_paint_get_text_skew_x (handle);
			}
			set {
				SkiaApi.sk_paint_set_text_skew_x (handle, value);
			}
		}

	}
}
