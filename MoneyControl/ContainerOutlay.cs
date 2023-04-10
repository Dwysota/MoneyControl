namespace MoneyControl
{
    public class ContainerOutlay
    {
        private const string FileNamesOutlays = "NamesOutlays.txt";
        private const string FilePrefixValuesOutlays = "ValuesOutlays-";
        List<Outlay> outlays = new List<Outlay>();
        public int PositionSelected { get; set; }
        public ContainerOutlay()
        {
            PositionSelected = -1;
            if (File.Exists(FileNamesOutlays))
            {
                using (var file = File.OpenText(FileNamesOutlays))
                {
                    var line = file.ReadLine();
                    while (line != null)
                    {
                        outlays.Add(new Outlay(line));
                        if (File.Exists($"{FilePrefixValuesOutlays}{line}.txt"))
                        {
                            using (var fileValues = File.OpenText($"{FilePrefixValuesOutlays}{line}.txt"))
                            {
                                var lineValue = fileValues.ReadLine();
                                while (lineValue != null)
                                {
                                    outlays[outlays.Count - 1].AddTransactionValue(lineValue);
                                    lineValue = fileValues.ReadLine();
                                }

                            }

                        }
                        line = file.ReadLine();
                    }

                }
            }
        }
        public void AddNewNameOutlay(string name)
        {
            outlays.Add(new Outlay(name));
            using (var file = File.AppendText(FileNamesOutlays))
            {
                file.WriteLine(name);
            }
        }

        public void AddValueToOutlay(string value)
        {
            this.outlays[PositionSelected].AddTransactionValue(value);
            using (var file = File.AppendText($"{FilePrefixValuesOutlays}{this.outlays[PositionSelected].Name}.txt"))
            {
                file.WriteLine(value);
            }
        }
        public void SetPosition(string position)
        {
            if (int.TryParse(position, out int pos))
            {
                if (pos - 1 >= -1)
                {
                    this.PositionSelected = pos - 1;
                }
                    
            }
            else
            {
                throw new Exception("Wrong value for name of Outlay.");
            }
        }
        public string ShowListOutlays()
        {
            string menuList = "";
            int i = 0;
            foreach (var Outlay in outlays)
            {
                i++;
                menuList += $"{i}. {Outlay.Name}\n";
            }
            return menuList;
        }
        public string ShowListValuesForOutlays()
        {
            string valuesOutlay = "";
            int i = 0;
            foreach (var value in outlays[PositionSelected].values)
            {
                i++;
                valuesOutlay += $"{i}. {value}\n";
            }
            return valuesOutlay;
        }
        public Outlay getActiveOutlay()
        {
            return  outlays[PositionSelected];
        }
    }
}
