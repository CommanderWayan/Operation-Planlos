using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OP_Editor.Layers;
using System.Collections;

namespace OP_Editor.Map
{
    public class Map
    {
        int _baseLayerWidth;
        int _baseLayerHeight;
        float _baseParallaxValueVert;
        float _baseParallaxValueHorz;
        int _tileWidth = -1;
        int _tileHeight = -1;
        string _name;

        bool enableBaseLayerModification = false;        

        List<MapLayer> _layers = new List<MapLayer>();

        public Map(string Name, int XTiles, int YTiles, float BaseParallaxValueVert, float BaseParallaxValueHorz)
        {
            this._baseLayerHeight = YTiles;
            this._baseLayerWidth = XTiles;
            this._baseParallaxValueHorz = BaseParallaxValueHorz;
            this._baseParallaxValueVert = BaseParallaxValueVert;
            this._layers.Add(new MapLayer("Base", _baseLayerWidth, _baseLayerHeight, _baseParallaxValueVert, _baseParallaxValueHorz));            
            this._name = Name;
        }

        public int LayerCount { get { return this._layers.Count; } }
        public List<MapLayer> Layers { get { return this._layers; } }
        public MapLayer BaseLayer { get { return this._layers[0]; } }
        public string Name 
        {
            get { return this._name; } 
            set { this._name = value; } 
        }
        public void SetTileDimensions(int TileWidth, int TileHeight)
        {
            this._tileWidth = TileWidth;
            this._tileHeight = TileHeight;
        }
        public int TileWidth { get { return this._tileWidth; } }
        public int TileHeight { get { return this._tileHeight; } }

        private void RecalculateParallaxValues(int NewBaseIndex)
        {
            float factorVert, factorHorz;
            for (int i = 0; i < _layers.Count; i++)
            {
                if (i != NewBaseIndex)
                {
                    factorVert = _layers[i].ParallaxValueVertical / _baseParallaxValueVert;
                    factorHorz = _layers[i].ParallaxValueHorizontal / _baseParallaxValueHorz;
                    //Verhältnisse neu setzen
                    _layers[i].ParallaxValueHorizontal = _layers[NewBaseIndex].ParallaxValueHorizontal * factorHorz;
                    _layers[i].ParallaxValueVertical = _layers[NewBaseIndex].ParallaxValueVertical * factorVert;
                }
            }
            //baseparallax neu setzen
            _baseParallaxValueHorz = _layers[NewBaseIndex].ParallaxValueHorizontal;
            _baseParallaxValueVert = _layers[NewBaseIndex].ParallaxValueVertical;
        }

        public void AddLayer(string Name, int XTiles, int YTiles, float ParallaxFactorVert, float ParallaxFactorHorz)
        {
            _layers.Add(new MapLayer(Name, XTiles, YTiles, _baseParallaxValueVert * ParallaxFactorVert, _baseParallaxValueHorz * ParallaxFactorHorz));            
        }
        public void RemoveLayer(int Index)
        {
            Console.WriteLine(Index);
            if (Index != 0)
                _layers.RemoveAt(Index);
            else
            {
                //first - wenn letzter layer ist der nicht entfernbar
                if (_layers.Count == 1)
                {
                    //TODO: Info das der letzte layer nicht gelöscht werden kann
                }               
                else
                {
                    if (enableBaseLayerModification)
                    {
                        RecalculateParallaxValues(Index + 1);
                        _layers.RemoveAt(Index); //Jetzt Layer entfernen
                    }
                }
            }
        }        
        public void MoveLayerUp(int IndexOfLayer)
        {
            //letzter Layer kann nicht hoch bewegt werden
            if (IndexOfLayer == _layers.Count - 1) { }
            else
            {
                //Wenn Index ist Base dann muss base neu berechnet werden
                if (IndexOfLayer == 0)
                {
                    if (enableBaseLayerModification)
                    {
                        MapLayer temp = new MapLayer(_layers[IndexOfLayer]);
                        _layers[IndexOfLayer] = _layers[IndexOfLayer + 1];
                        _layers[IndexOfLayer + 1] = temp;
                        RecalculateParallaxValues(0);
                    }
                }
                //Sonst positionen vertauschen
                else
                {
                    MapLayer temp = new MapLayer(_layers[IndexOfLayer]);
                    _layers[IndexOfLayer] = _layers[IndexOfLayer + 1];
                    _layers[IndexOfLayer + 1] = temp;
                }                
            }
        }
        public void MoveLayerDown(int IndexOfLayer)
        {
            //0 kann nicht nach unten bewegt werden
            if (IndexOfLayer == 0) { }
            else
            {
                //wenn index 1 dann wird neuer base erzeugt
                if (IndexOfLayer == 1)
                {
                    if (enableBaseLayerModification)
                    {
                        MapLayer temp = new MapLayer(_layers[IndexOfLayer]);
                        _layers[IndexOfLayer] = _layers[IndexOfLayer - 1];
                        _layers[IndexOfLayer - 1] = temp;
                        RecalculateParallaxValues(0);
                    }
                }
                //Sonst positionen vertauschen
                else
                {
                    MapLayer temp = new MapLayer(_layers[IndexOfLayer]);
                    _layers[IndexOfLayer] = _layers[IndexOfLayer - 1];
                    _layers[IndexOfLayer - 1] = temp;
                }
            }
        }        
        public void draw()
        {
            //TODO: draw
        }
    }
}
