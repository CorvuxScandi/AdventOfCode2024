
using System.Data.Common;
using System.Dynamic;

namespace AdventCalendar.Days;

public class Day4 : IDay
{
    private readonly string _target = "XMAS";
    private readonly string _targetR = "SAMX";
    public Task<CalendarAnswer> Run()
    {
        string[] input = _input.Split(Environment.NewLine);
        throw new NotImplementedException();
    }

    public Task<CalendarAnswer> RunAdvanced()
    {
        throw new NotImplementedException();
    }

    private static int GetHorizontal(string row){
        int count = 0;
        for (int i = 0; i < row.Length; i++)
        {
            if(row[i] == 'X'){
                if(i > 3 && row[i-1] == 'M' && row[i-2] == 'A' && row[i-3] == 'S'){
                    count++;
                }
                else if(i < row.Length - 4 && row[i+1] == 'M' && row[i+2] == 'A' && row[i+3] == 'S'){
                    count++;
                }
            }
        }
        return count;
    }
    private static int GetVertical(string[] rows, int rowIndex){
        int count = 0;
        

        return count;
    }
    private readonly string _inputTest = @"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX";
    private readonly string _input = @"";
    }