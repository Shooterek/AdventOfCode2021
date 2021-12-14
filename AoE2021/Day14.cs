﻿using AoE2021.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoE2021
{
    public class Day14 : Day
    {
        public Day14() : base("day14")
        {
        }

        protected override object FirstTask()
		{
			var input = this._inputLoader.LoadStringBatches();
			var instr = input[0];

			var instructions = input[1].Split("\r").Select(x =>
			{
				var split = x.Split(" -> ");
				return (instr: split[0].Trim(), result: split[1]);
			}).ToList();

			for (int i = 0; i < 10; i++)
			{
				var sb = new StringBuilder();
				sb.Append(instr);
				for (int j = 0; j < instr.Length - 1; j++)
				{
					var z = $"{instr[j]}{instr[j + 1]}";
					var charToInsert = instructions.First(x => x.instr == z).result;
					sb.Insert(1 + j * 2, charToInsert);
				}
				instr = sb.ToString();
			}

			var x = instr.GroupBy(x => x).Select(x => x.Count()).OrderByDescending(y => y);

			return x.First() - x.Last();
		}

		protected override object SecondTask()
		{
			var input = this._inputLoader.LoadStringBatches();
			var instr = input[0];

			var instructions = input[1].Split("\r").Select(x =>
			{
				var split = x.Split(" -> ");
				return (instr: split[0].Trim(), result: split[1]);
			}).ToDictionary(x => x.instr, x => x.result);

			for (int i = 0; i < 10; i++)
			{
				var sb = new StringBuilder();
				sb.Append(instr);
				for (int j = 0; j < instr.Length - 1; j++)
				{
					var z = $"{instr[j]}{instr[j + 1]}";
					var charToInsert = instructions[z];
					sb.Insert(1 + j * 2, charToInsert);
				}
				instr = sb.ToString();
			}

			var x = instr.GroupBy(x => x).Select(x => x.Count()).OrderByDescending(y => y);

			return x.First() - x.Last();
		}
    }
}
