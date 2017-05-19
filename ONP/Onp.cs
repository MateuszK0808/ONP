using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONP
{
    class Onp
    {
        private readonly string _wejscie;
        private List<char> _stos;
        private List<char> wyjscie;

        public Onp(string wejscie)
        {
            _wejscie = wejscie;
            _stos = new List<char>();
            wyjscie = new List<char>();
        }
        public List<char> ToOnp()
        {
            for (int i =0; i < _wejscie.Length; i++)
            {
                char znak = _wejscie[i];

                if (znak == '(')_stos.Add(znak);
                else if (znak == ')') ClearStos(znak);

                else if (znak == '+' || znak == '-' ||
                         znak == '*' || znak == '/' ||
                         znak == '^')
                {
                    if (_stos.Count == 0) _stos.Add(znak);
                    else
                    {
                        if (Priorytet(znak) <= Priorytet(_stos[_stos.Count - 1])) ClearStos(znak);
                        else _stos.Add(znak);
                    }
                }
                else
                {
                    wyjscie.Add(znak);
                    if ( wyjscie.Count >=2 && i + 1 < _wejscie.Length &&
                        _wejscie[i-1] == wyjscie[wyjscie.Count-2] && 
                        Priorytet(_wejscie[i + 1]) > -1)
                    {
                        wyjscie.Add(' ');
                    }
                }
            }
            ClearStos('0');
            return wyjscie;
        }

        private void ClearStos(char znak)
        {
            for (int i = _stos.Count -1; i >=0 ; i--)
            {
                if (_stos[i] == '(' && znak == ')')
                {
                    _stos.RemoveAt(i);
                    return; 
                }
                else if (Priorytet(znak)<=Priorytet(_stos[i]))
                {
                    wyjscie.Add(_stos[i]);
                    _stos.RemoveAt(i);
                }
                else break;
            }
            _stos.Add(znak);
            
        }

        private int Priorytet(char znak)
        {
            if (znak == '+' || znak == '-') return 1;
            else if (znak == '*' || znak == '/') return 2;
            else if (znak == '^') return 3;
            else if (znak == '(' || znak == ')') return 0;
            else return -1;
        }
    }
}
