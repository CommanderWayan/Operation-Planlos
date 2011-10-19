using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OP_Editor.Textures;
using System.Xml;
using System.Drawing;

namespace OP_Editor.ContentReaders
{
    class TextureSheetReader
    {
        TextureSheet _textureSheet;
        FileInfo _sheetFile;
        FileInfo _sheetDatFile;
        int _width, _height;
        

        public TextureSheetReader()
        {
            
        }
        public TextureSheet loadTextureSheet(FileInfo SheetFile)
        {
            this._sheetFile = SheetFile;
            if (searchTextureDatFile())
            {
                buildTextureSheet();
                return _textureSheet;
            }
            else
                return null;
            
        }

        private void buildTextureSheet()
        {
            _textureSheet = new TextureSheet(_width, _height, Image.FromFile((_sheetFile.FullName),true));
        }
        private bool searchTextureDatFile()
        {
            bool success = false;
			string temp = Path.ChangeExtension(_sheetFile.FullName, "dat");
            _sheetDatFile = new FileInfo(temp);
				
            if (_sheetDatFile.Exists)
            {
                //DAT IS DA - lies aus
                XmlDocument doc = new XmlDocument();
                doc.Load(_sheetDatFile.FullName);
                XmlNode spritewidth = doc.DocumentElement.SelectSingleNode("/TextureSheet/SpriteDimensions/SpriteWidth");
                XmlNode spriteheight = doc.DocumentElement.SelectSingleNode("/TextureSheet/SpriteDimensions/SpriteHeight");                    
                if (int.TryParse(spritewidth.InnerText, out _width) && int.TryParse(spriteheight.InnerText, out _height))
                {                        
                    success = true;
                }                    
                return success;
            }
            else
            {
                return success;
                //TODO: Exception wenn DAT Datei nicht da ist!
            }            
        }
    }
}
