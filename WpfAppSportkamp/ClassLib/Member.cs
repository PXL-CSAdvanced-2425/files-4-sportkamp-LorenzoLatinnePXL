﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Member
    {
        private Dictionary<string, Sport> _sportTable;
        private WeekRegistration[] _weekOverview;

        public double CampPrice
        {
            get
            {
                switch (SportCode)
                {
                    case ("ATL"):
                        return 190;
                    case ("VOE"):
                        return 190;
                    case ("ZWE"):
                        return 210;
                    case ("KAY"):
                        return 250;
                    case ("TEN"):
                        return 260;
                    case ("PAA"):
                        return 310;
                    case "VOL":
                        return 190;
                    default:
                        return 0;
                }
            }

        }
        public int CampNr { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string FullName { get { return $"{Name} {FirstName}"; } }
        public string SportCode { get; set; }
        public string SportName
        {
            get
            {
                switch (SportCode)
                {
                    case ("ATL"):
                        return "Atletiek";
                    case ("VOE"):
                        return "Voetbal";
                    case ("ZWE"):
                        return "Zwemmen";
                    case ("KAY"):
                        return "Kayak";
                    case ("TEN"):
                        return "Tennis";
                    case ("PAA"):
                        return "Paardrijden";
                    case "VOL":
                        return "Volleybal";
                    default:
                        return "Invalid.";
                }
            }
        }

        public double PriceToPay
        {
            get
            {
                if (CampNr == 1)
                    return CampPrice;
                else if (CampNr > 1 && CampNr < 5)
                    return CampPrice * 0.95;
                else
                    return CampPrice * 0.90;
            }

        }
        public int WeekNr { get; set; }

        public string FullInformation()
        {
            return $"{(FirstName + " " + Name).PadRight(30)}" +
                   $"{SportName.PadRight(20)} {CampPrice:c} - {CampNr} - {PriceToPay:c}";
        }

        public List<Member> ReadMembers(string file)
        {
            List<Member> members = new List<Member>();

            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        Member currentMember = new Member();
                        string currentLine = sr.ReadLine();
                        currentMember.Name = currentLine.Substring(0, 30).Trim();
                        currentMember.FirstName = currentLine.Substring(30, 30).Trim();
                        currentMember.SportCode = currentLine.Substring(61, 3);
                        currentMember.WeekNr = int.Parse(currentLine.Substring(60, 1));
                        currentMember.CampNr = int.Parse(currentLine.Substring(64, 1));

                        members.Add(currentMember);
                    }
                }
            }
            return members;
        }

        public Dictionary<string, Sport> ReadSportsTable(string file)
        {
            throw new Exception();
        }

        public string ShowMembers(List<Member> members)
        {
            StringBuilder showMembers = new StringBuilder();
            foreach (Member member in members)
            {
                showMembers.AppendLine(member.FullInformation());
            }
            return showMembers.ToString();
        }

        public string ShowSportsTypeOverview(List<Member> members)
        {
            StringBuilder sb = new StringBuilder();
            int count;
            double sum;

            for (int i = 0; i < 7; i++)
            {
                count = 0;
                sum = 0;
                foreach (Member member in members)
                {
                    if (member.SportCode == "ATL" && i == 0)
                    {
                        count++;
                        sum += member.PriceToPay;
                    }
                    else if (member.SportCode == "VOE" && i == 1)
                    {
                        count++;
                        sum += member.PriceToPay;
                    }
                    else if (member.SportCode == "ZWE" && i == 2)
                    {
                        count++;
                        sum += member.PriceToPay;
                    }
                    else if (member.SportCode == "KAY" && i == 3)
                    {
                        count++;
                        sum += member.PriceToPay;
                    }
                    else if (member.SportCode == "TEN" && i == 4)
                    {
                        count++;
                        sum += member.PriceToPay;
                    }
                    else if (member.SportCode == "PAA" && i == 5)
                    {
                        count++;
                        sum += member.PriceToPay;
                    }
                    else if (member.SportCode == "VOL" && i == 6)
                    {
                        count++;
                        sum += member.PriceToPay;
                    }

                }
                switch (i)
                {
                    case (0):
                        sb.AppendLine($"{"Atletiek".PadRight(15)}- {count} {"inschrijvingen:".PadRight(20)} {sum:c}");
                        break;
                    case (1):
                        sb.AppendLine($"{"Voetbal".PadRight(15)}- {count} {"inschrijvingen:".PadRight(20)} {sum:c}");
                        break;
                    case (2):
                        sb.AppendLine($"{"Zwemmen".PadRight(15)}- {count} {"inschrijvingen:".PadRight(20)} {sum:c}");
                        break;
                    case (3):
                        sb.AppendLine($"{"Kayak".PadRight(15)}- {count} {"inschrijvingen:".PadRight(20)} {sum:c}");
                        break;
                    case (4):
                        sb.AppendLine($"{"Tennis".PadRight(15)}- {count} {"inschrijvingen:".PadRight(20)} {sum:c}");
                        break;
                    case (5):
                        sb.AppendLine($"{"Paardrijden".PadRight(15)}- {count} {"inschrijvingen:".PadRight(20)} {sum:c}");
                        break;
                    case (6):
                        sb.AppendLine($"{"Volleybal".PadRight(15)}- {count} {"inschrijvingen:".PadRight(20)} {sum:c}");
                        break;
                }

            }
            return sb.ToString();


        }

        public string ShowWeekOverview(List<Member> members)
        {
            StringBuilder sb = new StringBuilder();
            int count;
            double sum;

            for (int i = 0; i < members.Max(x => x.WeekNr); i++)
            {
                count = 0;
                sum = 0;
                foreach (Member member in members)
                {
                    if (member.WeekNr == (i + 1))
                    {
                        count++;
                        sum += member.PriceToPay;
                    }
                }
                sb.AppendLine($"Week {i + 1} - {count} inschrijvingen \t {sum:c}");
            }
            return sb.ToString();
        }

    }
}
