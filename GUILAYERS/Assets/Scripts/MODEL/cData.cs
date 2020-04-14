using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using JetBrains.Annotations;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Assets.Scripts.MODEL
{
    /// <summary>
    /// cData Description:
    /// Created By: rossy
    /// History:
    ///   Created on: 3/4/2020 8:04:54 AM
    /// </summary>
    struct SudoData
    {
        public int Value;
        public bool Hidden;
        public SudoData(int value, bool hidden = false)
        {
            Value = value;
            Hidden = hidden;
        }
        public override string ToString()
        {
            if (Hidden)
                return " ";
            else
                return Value.ToString();
        }
    }
    public class cData
    {
        #region PRIVATE MEMBERS
        SudoData[][][] _dataArray;
        #endregion

        #region PUBLIC MEMBERS

        #endregion

        #region CONSTRUCTION
        /// <summary>
        /// cData Constructor:
        /// </summary>
        public cData()
        {
            _dataArray = new SudoData[g.PUZZLESIZE][][];
            for (int layer = 0; layer < g.PUZZLESIZE; layer++)
            {
                _dataArray[layer] = new SudoData[g.PUZZLESIZE][];
                for (int row = 0; row < g.PUZZLESIZE; row++)
                {
                    _dataArray[layer][row] = new SudoData[g.PUZZLESIZE];
                    for (int col = 0; col < g.PUZZLESIZE; col++)
                    {
                        _dataArray[layer][row][col].Value = 0;
                        _dataArray[layer][row][col].Hidden = true;
                    }
                }

            }

        }
        #endregion

        #region PUBLIC ACCESS

        #endregion

        #region PRIVATE METHODS
        public bool ReadData()
        {
            bool success = false;
            try
            {
                using (StreamReader stread = new StreamReader(@"C:\TMP\PUZZLE1.csv"))
                {
                    int pid = readHeader(stread);
                    string sline;
                    while ((sline = stread.ReadLine()) != null)
                    {
                        parseLine(sline);
                    }
                    success = stread.EndOfStream;
                }

            }
            catch (Exception x)
            {
                throw new Exception($"cData.ReadData(): {x.Message}");
            }

            return success;
        }

        private void parseLine(string sline)
        {

            int lid, rid = 0;
            int[] cols = null;
            try
            {
                lid = getNextInt(ref sline);
                rid = getNextInt(ref sline);
                readCols(sline, ref cols);
                for (int cid = 0; cid < g.PUZZLESIZE; cid++)
                {
                    _dataArray[lid][rid][cid] = new SudoData(cols[cid]);
                }
            }
            catch (Exception x)
            {
                throw new Exception($"cData.parseLine(): {x.Message}");
            }
        }

        private void readCols(string sline, ref int[] cols)
        {
            try
            {
                cols = new int[g.PUZZLESIZE];
                var aCols = sline.Split(',');
                for (int iCol = 0; iCol < aCols.Length; iCol++)
                {
                    cols[iCol] = int.Parse(aCols[iCol]);
                }
            }
            catch (Exception x)
            {
                throw new Exception($"cData.readCols(): {x.Message}");
            }
        }

        private int getNextInt(ref string sline)
        {
            int retInt;
            try
            {
                int index = sline.IndexOf(",");
                retInt = int.Parse(sline.Substring(0, index));
                sline = sline.Substring(index + 1); // past following ','
            }
            catch (Exception x)
            {
                throw new Exception($"cData.getNextInt(): {x.Message}");
            }
            return retInt;
        }


        private int readHeader(StreamReader stread)
        {
            try
            {
                string s = stread.ReadLine();
                int retPid = int.Parse(s.Substring("PID ".Length, 1));
                //_ = stread.ReadLine(); // read past column names.
                return retPid;
            }
            catch (Exception x)
            {
                throw new Exception($"cData.readHeader(): {x.Message}");
            }
        }
        #endregion

        #region PUBLIC METHODS

        #endregion
    }
}
