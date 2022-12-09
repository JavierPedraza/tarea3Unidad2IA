using System;
using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;

class Nodo
{
    private List<Nodo> hijos = null;
    private string nombre;

    public Nodo(string nombre)
    {
        this.hijos = new List<Nodo>();
        this.nombre = nombre;
    }

    public List<Nodo> getHijos()
    {
        return this.hijos;
    }

    public string getNombre()
    {
        return this.nombre;
    }

    public void agregarHijo(Nodo newChild)
    {
        this.hijos.Add(newChild);
    }

}

class BuscadorNodo
{
    public void busquedaProf(Nodo Raiz)
    {
        if(Raiz != null)
        {
            List<Nodo> lista = Raiz.getHijos();
            String nombre = "";
            if (lista.Count != 0)
            {
                foreach(Nodo hijin in lista)
                {
                    busquedaProf(hijin);
                }
                nombre = Raiz.getNombre();
                Console.WriteLine(nombre);
            }
            else
            {
                nombre = Raiz.getNombre();
                Console.WriteLine(nombre);
            }
        }
    }

}


class Reinas
{

    int tamaño = 8;
    int[,] tablero;
    int[] rowOcupadas;
    int[] colOcupadas;

    public Reinas()
    {
        tablero = new int[this.tamaño, this.tamaño];
        rowOcupadas = new int[tamaño];
        colOcupadas = new int[tamaño];


        //checando como se imprimen (no he usado mucho el C#)
        //for (int i = 0; i < tamaño; i++)
        //{
        //    for (int j = 0; j < tamaño; j++)
        //    {
        //        Console.Write(tablero[i, j]);
        //    }
        //    Console.WriteLine();
        //}

    }

    public void resolverReinas()
    {
        Random rnd = new Random();
        int rowInicial = rnd.Next(0, 7);
        
        agregarReina(rowInicial,0);

        for (int i = 0; i < (tamaño-1); i++)
        {
            findSafe();
        }

    }

    private void findSafe()
    {
        bool Agregado = false;
        for(int i = 0; i < (tamaño - 1); i++)
        {
            //checa si la hilera actual ya tiene reina
            if (rowOcupadas[i] == 1) continue;
            else
            {
                for(int j = 0; j < (tamaño - 1); j++)
                {
                //chequa si la columna actual ya tiene reina
                    if (colOcupadas[j] == 1) continue;
                    else
                    {
                        //checando las diagonales
                        if (encontrarDiagIzSup(i, j) && 
                            encontrarDiagDerSup(i,j) && 
                            encontrarDiagIzInf(i,j) && 
                            encontrarDiagDerInf(i,j)
                            )
                        {
                            agregarReina(i, j);
                            Agregado = true;
                            break;
                        }
                    }
                }
            }
            if (Agregado == true) break;
        }
    }
    //Bools para checar diagonales
    private bool encontrarDiagIzSup(int i, int j)
    {
        int diag1, diag2;
        diag1 = i-1;
        diag2 = j-1;
        //checa diagonal izquierda superior
        while (diag1 >= 0 && diag2 >= 0)
        {
            if (tablero[diag1, diag2] == 1) return false;
            diag1--;
            diag2--;
        }
        return true;
    }
    private bool encontrarDiagDerSup(int i, int j)
    {
        int diag1, diag2;
        diag1 = i+1;
        diag2 = j+1;
        //checa diagonal derecha superior
        while (diag1 < tamaño && diag2 < tamaño)
        {
            if (tablero[diag1, diag2] == 1) return false;
            diag1++;
            diag2++;
        }
        return true;

    }
    private bool encontrarDiagIzInf(int i, int j)
    {
        int diag1, diag2;
        diag1 = i+1;
        diag2 = j-1;

        //checa diagonal izquierda inferior
        while (diag1 < tamaño && diag2 >= 0)
        {
            if (tablero[diag1, diag2] == 1) return false;
            diag1++;
            diag2--;
        }

        return true;
    }
    private bool encontrarDiagDerInf(int i, int j)
    {
        int diag1, diag2;
        diag1 = i-1;
        diag2 = j+1;
        //checa diagonal derecha inferior
        while (diag1 >= 0 && diag2 < tamaño)
        {
            if (tablero[diag1 , diag2] == 1) return false;
            diag1--;
            diag2++;
        }
        return true;
    }



        void agregarReina(int row, int col)
    {
        this.tablero[row, col] = 1;
        this.rowOcupadas[row] = 1;
        this.colOcupadas[col] = 1;
        Console.WriteLine($"Reina agregada en {row} , {col}");
    }

}



namespace Arboles
{
    class programa
    {
        static void Main(string[] args)
        {
            BuscadorNodo buscador = new BuscadorNodo();

            

            Nodo raiz = new Nodo("raiz");
            //Populamos el primer nivel
            Nodo hijo1 = new Nodo("Hijo1");
            Nodo hijo2 = new Nodo("Hijo2");
            Nodo hijo3 = new Nodo("Hijo3");
            Nodo hijo4 = new Nodo("Hijo4");

            raiz.agregarHijo(hijo1);
            raiz.agregarHijo(hijo2);
            raiz.agregarHijo(hijo3);
            raiz.agregarHijo(hijo4);

            Nodo nieto1 = new Nodo("Nieto1");
            Nodo nieto2 = new Nodo("Nieto2");
            Nodo nieto3 = new Nodo("Nieto3");

            hijo1.agregarHijo(nieto1);
            hijo3.agregarHijo(nieto2);
            hijo4.agregarHijo(nieto3);

            Nodo hoja1 = new Nodo("Hoja1");
            Nodo hoja2 = new Nodo("Hoja2");

            nieto2.agregarHijo(hoja1);
            nieto3.agregarHijo(hoja2);

            buscador.busquedaProf(raiz);

            Dictionary<int, Nodo> chessboard = new Dictionary<int, Nodo>();

            Reinas reinita = new Reinas();

            reinita.resolverReinas();

        }



    }
}