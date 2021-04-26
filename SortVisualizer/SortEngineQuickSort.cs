using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class SortEngineQuickSort: ISortEngine
    {
        private int[] TheArray;
        private Graphics g;
        private int MaxVal;
        private int Height;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public SortEngineQuickSort (int[] TheArray_In, Graphics g_In, int MaxVal_In, int Height_In)
        {
            TheArray = TheArray_In;
            g = g_In;
            MaxVal = MaxVal_In;
            Height =  Height_In;
        }
        public  void QuickSortNow(int[] iInput, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(iInput, start, end);
                QuickSortNow(iInput, start, pivot - 1);
                QuickSortNow(iInput, pivot + 1, end);
            }
        }

        public  int Partition(int[] iInput, int start, int end)
        {
            int pivot = iInput[end];
            int pIndex = start;

            for (int i = start; i < end; i++)
            {
                if (iInput[i] <= pivot)
                {
                    Swap(i, pIndex, iInput);
                    pIndex++;
                }
            }

            Swap(pIndex, end, iInput);
            return pIndex;
        }

        private  void Swap(int pIndex, int end, int[] iInput)
        {
            int anotherTemp = iInput[pIndex];
            iInput[pIndex] = iInput[end];
            iInput[end] = anotherTemp;

            DrawBar(pIndex, iInput[pIndex]);
            DrawBar(end, iInput[end]);
        }

        public void NextStep()
        {
            QuickSortNow(TheArray, 0, TheArray.Count()-1);

        }

        private void DrawBar(int position, int height)
        {
            g.FillRectangle(BlackBrush, position, 0, 1, MaxVal);
            g.FillRectangle(WhiteBrush, position, MaxVal - height, 1, MaxVal);
        }

        private void Draw()
        {
            g.FillRectangle(BlackBrush, 0, 0, Height, MaxVal);

            for (int i = 0; i < TheArray.Count(); i++) { 
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - TheArray[i], 1, MaxVal);
        }
        }

        public bool IsSorted()
        {
            for (int i = 0; i < TheArray.Count() - 1; i++)
            {
                if (TheArray[i] > TheArray[i + 1]) return false;
            }
            return true;
        }

      

        public void ReDraw()
        {
            for (int i = 0; i < (TheArray.Count() - 1); i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - TheArray[i], 1, MaxVal);
            }
        }
    }
}
