using UnityEngine;
using System.Collections;


namespace PixelRender
{
	public struct QuantizedFloat
	{
		private float _quantizeStep;
		public float quantizeStep {
			get { return _quantizeStep; }
			set {
				_quantizeStep = value;
				UpdateQuantizedValue();
			}
		}

		private float _realValue;
		public float realValue {
			get { return _realValue; }
			set {
				_realValue = value;
				UpdateQuantizedValue();
			}
		}

		private float _offset;
		public float offset {
			get { return _offset; }
			set {
				_offset = value - Quantize( value);
				UpdateQuantizedValue();
			}
		}

		private float _quantizedValue;
		public float quantizedValue { get { return _quantizedValue; } }

		private void UpdateQuantizedValue()
		{
			_quantizedValue = Quantize( _realValue) + _offset;
		}

		private float Quantize( float input)
		{
			return Mathf.Floor( input / _quantizeStep) * _quantizeStep;
		}
	}
}
