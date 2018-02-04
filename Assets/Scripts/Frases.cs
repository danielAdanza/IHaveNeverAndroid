using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Frases : IComparable<Frases>
{
    public int id           { get; set; }
    public string textSP    { get; set; }
    public string textEN    { get; set; }
    public int categoria    { get; set; }
    public int tipo         { get; set; }

    public Frases (int id, string textSP, string textEN, int categoria, int tipo)
    {
        this.id = id;
        this.textSP = textSP;
        this.textEN = textEN;
        this.categoria = categoria;
        this.tipo = tipo;
    }

    public Frases(Frases v)
    {
        this.id = v.id;
        this.textSP = v.textSP;
        this.textEN = v.textEN;
        this.categoria = v.categoria;
        this.tipo = v.tipo;
    }

    public int CompareTo(Frases other)
    {
        //if the first is larger than the second we will return -1
        //if they are equal then we will return 0
        //if the first is smaller then we will return 1;
        int result = 0;

        if (other.id > this.id)
        {
            result = 1;
        }
        else if (other.id < this.id)
        {
            result = -1;
        }
        return result;
    }
}

