using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper
{
    public class SudokuWrapper
    {

        private Sudoku.Game _game = new Sudoku.Game();

        public SudokuWrapper()
        {
            _game.create();
            GetMap_DataView();
        }

        public List<List<int>> GetMap_Matrix()
        {
            var _map = new List<List<int>>();

            for (int x = 0; x < 9; x++)
            {
                _map.Add(new List<int>());
                for (int y = 0; y < 9; y++)
                {
                    short toAdd = 0;
                    _game.get((short)(x + 1), (short)(y + 1), out toAdd);
                    _map.ElementAt(x).Add(toAdd);
                }
            }
            return _map;
        }

        public DataView GetMap_DataView()
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
        }

        public void printMap(List<List<int>> map)
        {
            foreach (List<int> x in map)
            {
                foreach (int y in x)
                {
                    Console.Write(y + " ");
                }
                Console.WriteLine();
            }
        }

        public Boolean SetValue(int x, int y, int value)
        {
            int succeeded = 1;
            _game.set((short)(x + 1), (short)(y + 1), (short)value, out succeeded);

            if (succeeded == 0)
            {
                Console.WriteLine("Could not set value [" + value + "] on position [" + x + ", " + y + "]");
                return false;
            }
            return true;
        }

        public Boolean isValid()
        {
            int succeeded;

            _game.isValid(out succeeded);

            if (succeeded == 0)
            {
                Console.WriteLine("Invalid answer");
                return false;
            }
            return true;
        }
    }
}
