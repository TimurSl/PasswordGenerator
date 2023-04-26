using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MatrixRain
{
	public partial class MatrixRain : UserControl
	{
		#region public method and properties

		/**
		 * <summary>
		 * Constructor of the class
		 * </summary>
		 */
		public MatrixRain()
		{
			InitializeComponent();

			_DispatcherTimer.AutoReset = true;
			_DispatcherTimer.Elapsed += _DispatcherTimerTick;

			//when the component is loaded  we need to make some calculation
			Loaded += _MatrixRainLoaded;
		}

		/**
		 * <summary>
		 * method to call if we change the container dimension and we want the effect to adapt to the new dimension
		 * </summary>
		 */
		public void DimensionChanged()
		{
			_MyInitialize();
		}

		/**
		 * <summary>
		 * Method to set the animation parameter
		 * </summary>
		 *
		 * <param name="framePerSecond">Frame per second refresh (this parameter affect the "speed" of the rain)</param>
		 * <param name="fontFamily">Font family used</param>
		 * <param name="fontSize">Dimension of the font used</param>
		 * <param name="backgroundBrush">Brush of the control background (do not use alpha or opacity setting)</param>
		 * <param name="textBrush">Brush of the text</param>
		 * <param name="characterToDisplay">The character used for the rain will be randomly choose from this string</param>
		 */
		public void SetParameter(int framePerSecond = 30, FontFamily fontFamily = null, int fontSize = 16, Brush backgroundBrush = null, Brush textBrush = null, String characterToDisplay = "")
		{
			bool dispRunning = false;
			if (_DispatcherTimer.Enabled) {
				_DispatcherTimer.Stop();
				dispRunning = true;
			}

			if (fontSize > 0) {
				_RenderingEmSize = fontSize;
			}
			else {
				_RenderingEmSize = 16;
			}

			if (fontFamily == null) {
				if (_TextFontFamily == null) {
					_TextFontFamily = new FontFamily("Arial");
				}
			}
			else {
				_TextFontFamily = fontFamily;
			}

			if (characterToDisplay == "") {
				_AvaiableLetterChars = "abcdefghijklmnopqrstuvwxyz1234567890";
			}
			else {
				_AvaiableLetterChars = characterToDisplay;
			}

			new Typeface(_TextFontFamily, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal).TryGetGlyphTypeface(out this._GlyphTypeface);
			_LetterAdvanceWidth = this._GlyphTypeface.AdvanceWidths[0] * this._RenderingEmSize + 4;
			_LetterAdvanceHeight = this._GlyphTypeface.Height * this._RenderingEmSize;
			_BaselineOrigin = new Point(2, 2);

			bool newBbFlag = false;
			if (backgroundBrush == null) {
				if (_BackgroundBrush == null) {
					newBbFlag = true;
					_BackgroundBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
				}
			}
			else {
				newBbFlag = true;
				_BackgroundBrush = backgroundBrush;
				_BackgroundBrush.Opacity = 1;
			}

			if (newBbFlag) {
				MatrixCanvas.Background = _BackgroundBrush.Clone();
				_BackgroundBrush.Opacity = _BackgroundBrushOpacity;
				_BackgroundBrush.Freeze();
			}

			if (textBrush == null) {
				if (_TextBrush == null) {
					_TextBrush = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
				}
			}
			else {
				_TextBrush = textBrush;
			}
			_TextBrush.Freeze();

			if (framePerSecond > 0) {
				_FramePerSecond = framePerSecond;
			}
			else {
				if (_FramePerSecond == 0) {
					_FramePerSecond = 30;
				}
			}

			_DispatcherTimer.Interval = 1000D / _FramePerSecond;

			_Drops = new int[(int)(_CanvasRect.Width / _LetterAdvanceWidth)];
			for (var x = 0; x < _Drops.Length; x++) {
				_Drops[x] = 1;
			}

			if (dispRunning) {
				_DispatcherTimer.Start();
			}
		}


		/**
		 * <summary>
		 * Method to start the animation
		 * </summary>
		 */
		public void Start()
		{
			_DispatcherTimer.Start();
		}

		/**
		 * <summary>
		 * Method to stop the animation
		 * </summary>
		 */
		public void Stop()
		{
			_DispatcherTimer.Stop();
		}

		#endregion

		#region private variable and methods
		
		private bool _LoadedFlag = false;
		private int _FramePerSecond = 30;
		private Rect _CanvasRect;
		private CryptoRandom _CryptoRandom = new CryptoRandom();
		private int[] _Drops;
		private System.Windows.Media.Imaging.RenderTargetBitmap _RenderTargetBitmap;
		private WriteableBitmap _WriteableBitmap;
		private Brush _BackgroundBrush;
		private float _BackgroundBrushOpacity = 0.1F;
		private Brush _TextBrush;
		private FontFamily _TextFontFamily;
		private int _RenderingEmSize = 16;
		private GlyphTypeface _GlyphTypeface;
		private double _LetterAdvanceWidth;
		private double _LetterAdvanceHeight;
		private Point _BaselineOrigin;
		private String _AvaiableLetterChars = "abcdefghijklmnopqrstuvwxyz1234567890";
		Boolean _DispatcherTimerMonitorFlag = false;
		System.Timers.Timer _DispatcherTimer = new System.Timers.Timer();
		
		private void _MatrixRainLoaded(object sender, RoutedEventArgs e)
		{
			if (!_LoadedFlag) {
				_LoadedFlag = true;
				_MyInitialize();
			}
		}
		
		private void _MyInitialize()
		{
			_CanvasRect = new Rect(0, 0, MatrixCanvas.ActualWidth, MatrixCanvas.ActualHeight);

			_RenderTargetBitmap = new System.Windows.Media.Imaging.RenderTargetBitmap((int)_CanvasRect.Width, (int)_CanvasRect.Height, 96, 96, System.Windows.Media.PixelFormats.Pbgra32);
			_WriteableBitmap = new WriteableBitmap(_RenderTargetBitmap);
			// Get the MatrixCanvas and MatrixImage references
			

			MatrixImage.Source = _WriteableBitmap;
			MatrixCanvas.Measure(new System.Windows.Size(_RenderTargetBitmap.Width, _RenderTargetBitmap.Height));
			MatrixCanvas.Arrange(new System.Windows.Rect(new System.Windows.Size(_RenderTargetBitmap.Width, _RenderTargetBitmap.Height)));

			if (_CanvasRect.Height > 1000) {
				_BackgroundBrushOpacity = 0.06F;
			}
			else if (_CanvasRect.Height > 700) {
				_BackgroundBrushOpacity = 0.08F;
			}
			else _BackgroundBrushOpacity = 0.1F;

			SetParameter(framePerSecond: _FramePerSecond, fontSize: (int)_RenderingEmSize);
			_Drops = new int[(int)(_CanvasRect.Width / _LetterAdvanceWidth)];
			for (var x = 0; x < _Drops.Length; x++) {
				_Drops[x] = 1;
			}
		}
		private void _DispatcherTimerTick(object sender, EventArgs e)
		{
			if (!Dispatcher.CheckAccess()) {
				//synchronize on main thread
				System.Timers.ElapsedEventHandler dt = _DispatcherTimerTick;
				if (!_DispatcherTimerMonitorFlag) {
					Dispatcher.Invoke(dt, sender, e);
				}
				return;
			}

			_DispatcherTimerMonitorFlag = true;
			DrawingVisual dv = _RenderDrops();
			_RenderTargetBitmap.Render(dv); // slowest part because performed on CPU

			// _MyImageBackground.Source = _RenderTargetBitmap would consume a lot of ram, so I use a _WriteableBitmap to avoid ram increase at each refresh			
			_WriteableBitmap.Lock();
			_RenderTargetBitmap.CopyPixels(new Int32Rect(0, 0, _RenderTargetBitmap.PixelWidth, _RenderTargetBitmap.PixelHeight), _WriteableBitmap.BackBuffer, _WriteableBitmap.BackBufferStride * _WriteableBitmap.PixelHeight, _WriteableBitmap.BackBufferStride);
			_WriteableBitmap.AddDirtyRect(new Int32Rect(0, 0, _RenderTargetBitmap.PixelWidth, _RenderTargetBitmap.PixelHeight));
			_WriteableBitmap.Unlock();
			_DispatcherTimerMonitorFlag = false;
		}
		
		private DrawingVisual _RenderDrops()
		{
			DrawingVisual drawingVisual = new DrawingVisual();
			DrawingContext drawingContext = drawingVisual.RenderOpen();

			//Black BG for the canvas to fade away letter
			drawingContext.DrawRectangle(_BackgroundBrush, null, _CanvasRect);

			List<ushort> glyphIndices = new List<ushort>();
			List<double> advancedWidths = new List<double>();
			List<Point> glyphOffsets = new List<Point>();

			//looping over drops
			for (var i = 0; i < _Drops.Length; i++) {
				// new drop position
				double x = _BaselineOrigin.X + _LetterAdvanceWidth * i;
				double y = _BaselineOrigin.Y + _LetterAdvanceHeight * _Drops[i];

				// check if new letter does not goes outside the image
				if (y + _LetterAdvanceHeight < _CanvasRect.Height) {

					// add new letter to the drawing
					var glyphIndex = _GlyphTypeface.CharacterToGlyphMap[_AvaiableLetterChars[_CryptoRandom.Next(0, _AvaiableLetterChars.Length - 1)]];
					glyphIndices.Add(glyphIndex);
					advancedWidths.Add(0);
					glyphOffsets.Add(new Point(x, -y));
				}
				
				if (_Drops[i] * _LetterAdvanceHeight > _CanvasRect.Height && _CryptoRandom.NextDouble() > 0.775) {
					_Drops[i] = 0;
				}
				
				_Drops[i]++;
			}
			if (glyphIndices.Count > 0) {
				GlyphRun glyphRun = new GlyphRun(
									_GlyphTypeface,
									0,
									false,
									_RenderingEmSize,
									glyphIndices,
									_BaselineOrigin,
									advancedWidths,
									glyphOffsets,
									null,
									null,
									null,
									null,
									null);
				drawingContext.DrawGlyphRun(_TextBrush, glyphRun);
			}
			drawingContext.Close();

			return drawingVisual;
		}
		
	}
	#endregion
}

