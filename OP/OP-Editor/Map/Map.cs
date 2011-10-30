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
        float _BaseParallaxValueHorz;

        LinkedList<MapLayer> _layers = new LinkedList<MapLayer>();

        public Map(int XTiles, int YTiles, float BaseParallaxValueVert, float BaseParallaxValueHorz)
        {
            this._baseLayerHeight = YTiles;
            this._baseLayerWidth = XTiles;
            this._BaseParallaxValueHorz = BaseParallaxValueHorz;
            this._baseParallaxValueVert = BaseParallaxValueVert;
            this._layers.AddFirst(new MapLayer(_baseLayerWidth,_baseLayerHeight,BaseParallaxValueVert, BaseParallaxValueHorz));
        }
        public int LayerCount { get{return this._layers.Count;} }
    }
}
