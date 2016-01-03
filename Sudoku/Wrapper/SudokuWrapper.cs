using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Wrapper
{
    public class SudokuWrapper
    {
        private Sudoku.Game _game = new Sudoku.Game();

        public SudokuWrapper()
        {


            _game.create();
            printMap(GetMap_Matrix());
        }

        public List<List<int>> GetMap_Matrix()
        {
            var _map = new List<List<int>>();

            for (int y = 0; y < 9; y++)
            {
                _map.Add(new List<int>());
                for (int x = 0; x < 9; x++)
                {
                    short toAdd = 0;
                    _game.get((short)(x + 1), (short)(y + 1), out toAdd);
                    _map.ElementAt(y).Add(toAdd);
                }
            }
            return _map;
        }

        /*public DataView GetMap_DataView()
        {
            List<List<int>> l = GetMap_Matrix();
            DataTable table = new DataTable();
            for (int x = 0; x < 9; x++)
            {
                table.NewRow();
            }
            Console.WriteLine(table.Rows.Count);
            int m = 0;
            foreach  (DataRow row in table.Rows) 
            {
                m++;
                for (int i = 0; i < 9; i++)
                {
                    row.SetField(i, l.ElementAt(m).ElementAt(i));
                }
            }

            m = 0;
            foreach(DataRow row in table.Rows)
            {
                m++;
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(row.Field<int>(i) + " ");
                }
                Console.WriteLine();
            }

            return table.AsDataView();
        }*/

        public void printMap(List<List<int>> map)
        {
            Debug.WriteLine("____________________");
            foreach (List<int> x in map)
            {
                foreach (int y in x)
                {
                    Debug.Write(y + " ");
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("____________________");

        }

        public void Cheat()
        {
            int zeroCount = 0;
            foreach (var y in GetMap_Matrix())
            {
                foreach (var x in y)
                {
                    if (x == 0)
                        zeroCount++;
                }
            }

            foreach (var y in GetMap_Matrix())
            {

                foreach (var x in y)
                {
                    short yCord = 0;
                    short xCord = 0;
                    short val = 0;
                    int suc = 0;

                    if (zeroCount > 2)
                    {
                        _game.hint(out xCord, out yCord, out val, out suc);
                        if (suc == 1)
                        {
                            SetValue(yCord - 1, xCord - 1, val);
                        }
                        zeroCount--;
                    }
                }
            }

        }

        public Boolean SetValue(int x, int y, int value)
        {
            int succeeded = 1;
            _game.set((short)(y + 1), (short)(x + 1), (short)value, out succeeded);

            printMap(GetMap_Matrix());

            if (succeeded == 0)
            {
                Debug.WriteLine("Could not set value [" + value + "] on position [" + x + ", " + y + "]");
                return false;
            }
            return true;
        }

        public Boolean isFinished()
        {
            if (isValid())
            {
                foreach (var y in GetMap_Matrix())
                {
                    foreach (var x in y)
                    {
                        if (x == 0)
                            return false;
                    }
                }
                return true;
            }
            return false;
        }

        public Boolean isValid()
        {
            int succeeded;

            _game.isValid(out succeeded);

            if (succeeded == 0)
            {
                Debug.WriteLine("Invalid answer");
                return false;
            }
            return true;
        }
    }
}
