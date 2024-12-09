using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2024
{
    public class Puzzle_Day_09
    {
        private string FileSystem;
        private List<FileRecord> FileRecords = new List<FileRecord>();
        private List<string> RawFileMap;

        public Puzzle_Day_09(string filename)
        {
            FileSystem = InputHelper.ParseFile(InputHelper.GetInputFilePath("2024", filename));
            ParseInput();
            BuildFileMap();
        }

        public long Solve_Part01()
        {
            return GetCheckSum(CompactFileMap());
        }

        public long Solve_Part02()
        {
            return GetCheckSum(CompactFileMapV2());
        }

        private void ParseInput()
        {
            int i = 0;
            int indexID = 0;
            while (i < FileSystem.Length)
            {
                int id = indexID;
                int blocks = Int32.Parse(FileSystem[i].ToString());
                int free = i == FileSystem.Length - 1 ? 0 : Int32.Parse(FileSystem[i + 1].ToString());

                FileRecords.Add(new FileRecord(id, blocks, free));

                indexID++;
                i += 2;
            }
        }

        private void BuildFileMap()
        {
            RawFileMap = new List<string>();

            foreach (var file in FileRecords)
            {
                //add file.FileID to the map file.FileBlocks number of times
                for (int i = 0; i < file.FileBlocks; i++)
                {
                    RawFileMap.Add(file.FileID.ToString());
                }

                for (int i = 0; i < file.FreeSpace; i++)
                {
                    RawFileMap.Add(".");
                }
            }
        }

        private List<string> CompactFileMap()
        {
            //make a local copy of the file map into an array
            List<string> CompactedFileMap = RawFileMap;

            for (int i = CompactedFileMap.Count - 1; i >= 0; i--)
            {
                if (CompactedFileMap[i] != ".")
                {
                    string value = CompactedFileMap[i];

                    //find the first instance of '.' from the start
                    int firstDot = CompactedFileMap.IndexOf(".");

                    if (firstDot > i)
                        break;

                    //swap the two characters
                    CompactedFileMap[firstDot] = value;
                    CompactedFileMap[i] = ".";
                }
            }
            return CompactedFileMap;
        }

        //This one is SLOPPY, but it works
        private List<string> CompactFileMapV2()
        {
            // Make a local copy of the file map into a list
            List<string> CompactedFileMap = new List<string>(RawFileMap);
            List<int> alreadySwappedIndexes = new List<int>();

            for (int i = CompactedFileMap.Count - 1; i >= 0; i--)
            {
                if (!alreadySwappedIndexes.Contains(i) && CompactedFileMap[i] != ".")
                {
                    string value = CompactedFileMap[i];
                    int countOfId = CompactedFileMap.Count(x => x == value);

                    // Find the first sequence of 'countOfId' '.' in a row from the start
                    int firstSequenceStart = FindFirstSequenceOfDots(CompactedFileMap, countOfId);

                    // If we found a valid sequence, swap the sub-lists
                    if (firstSequenceStart != -1 && firstSequenceStart < i)
                    {
                        // Swap values into the sequence of dots
                        for (int j = 0; j < countOfId; j++)
                        {
                            CompactedFileMap[firstSequenceStart + j] = value;
                            CompactedFileMap[i - j] = ".";
                            alreadySwappedIndexes.Add(firstSequenceStart + j);
                            alreadySwappedIndexes.Add(i - j);
                        }
                    }
                }
            }

            return CompactedFileMap;
        }

        // Helper function to find the first sequence of 'count' dots
        private int FindFirstSequenceOfDots(List<string> fileMap, int count)
        {
            int sequenceLength = 0;
            for (int i = 0; i < fileMap.Count; i++)
            {
                if (fileMap[i] == ".")
                {
                    sequenceLength++;
                    if (sequenceLength == count)
                    {
                        // Return the start index of the valid sequence
                        return i - count + 1;
                    }
                }
                else
                {
                    sequenceLength = 0;
                }
            }

            // No valid sequence found
            return -1;
        }

        private long GetCheckSum(List<string> CompactedFileMap)
        {
            long checksum = 0;

            for (int i = 0; i < CompactedFileMap.Count; i++)
            {
                if (CompactedFileMap[i] == ".")
                    continue;

                checksum += (Int32.Parse(CompactedFileMap[i])) * i;
            }

            return checksum;
        }

        private string ConcatXTimes(string value, int times)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < times; i++)
            {
                sb.Append(value);
            }

            return sb.ToString();
        }
    }

    internal class FileRecord
    {
        public int FileID;
        public int FileBlocks;
        public int FreeSpace;

        public FileRecord(int id, int block, int free)
        {
            FileID = id;
            FileBlocks = block;
            FreeSpace = free;
        }
    }
}
