using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using OP_Editor.Textures;

namespace OP_Editor.Viewers
{
	class EditorTilePainter
	{
		Panel _panelToDrawTo;
		TextureSheet _textureSheet;
		Graphics gfx;
		Rectangle _drawzone = new Rectangle();
		public EditorTilePainter(Panel PanelToDrawTo, TextureSheet TextureSheet)
		{
			this._panelToDrawTo = PanelToDrawTo;
			this._textureSheet = TextureSheet;
			gfx = _panelToDrawTo.CreateGraphics();

			_panelToDrawTo.Width = _textureSheet.TileWidth * _textureSheet.XTiles;
			_panelToDrawTo.Height = _textureSheet.TileHeight * _textureSheet.YTiles;
		}
		public void DrawTiles()
		{
			_panelToDrawTo.Width = _textureSheet.TileWidth * _textureSheet.XTiles;
			_panelToDrawTo.Height = _textureSheet.TileHeight * _textureSheet.YTiles;
			for (int x = 0; x < _textureSheet.XTiles; x++)
			{
				for (int y = 0; y < _textureSheet.YTiles; y++)
				{
					_drawzone.X = x*_textureSheet.TileWidth;
					_drawzone.Y = y*_textureSheet.TileHeight;
					_drawzone.Width = _textureSheet.TileWidth;
					_drawzone.Height = _textureSheet.TileHeight;

					gfx.DrawImage(_textureSheet.getSpriteAtPosition(x, y),_drawzone);
				}
			}
			gfx.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
			
		}
	}
}
