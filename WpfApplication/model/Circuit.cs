using System;
using System.Data.SqlTypes;
using System.Xml.Serialization.Configuration;

namespace WpfApplication.model
{
    public class Circuit
    {
        private string _id = String.Empty;
        private string _lineNumber = string.Empty;
        private string _lineDescription = string.Empty;
        private float _voltage = 220;
        private bool _singlePhase = true;
        private double _powerFactor = 1;
        private double _current = 0;
        private double _power = 0;

        public string LineNumber
        {
            get => _lineNumber;
            set => _lineNumber = value;
        }

        public string LineDescription
        {
            get => _lineDescription;
            set => _lineDescription = value;
        }

        public float Voltage
        {
            get => _voltage;
            set => _voltage = value;
        }

        public bool SinglePhase
        {
            get => _singlePhase;
            set
            {
                _singlePhase = value;
                CalculateCurrent();
            }
        }

        public double PowerFactor
        {
            get => _powerFactor;
            set => _powerFactor = value;
        }

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public double Power
        {
            get => _power;
            set
            {
                _power = value;
                CalculateCurrent();
            }
        }

        public double Current
        {
            get => _current;
            set
            {
                _current = value;
                CalculatePower();
            }
        }

        private void CalculatePower()
        {
            if (SinglePhase)
            {
                _power = _voltage * _current * _powerFactor / 1000;
            }
            else
            {
                Power = Math.Sqrt(3) * _voltage * _current * _powerFactor / 1000;
            }
        }

        private void CalculateCurrent()
        {
            if (SinglePhase)
            {
                _current = _power / _voltage / _powerFactor * 1000;
            }
            else
            {
                _current = _power / Math.Sqrt(3) / _voltage / _powerFactor * 1000;
            }
        }
    }
}