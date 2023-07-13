using Newtonsoft.Json;


namespace SwEngHomework.Commissions
{
    public class CommissionCalculator : ICommissionCalculator
    {
        public IDictionary<string, double> CalculateCommissionsByAdvisor(string jsonInput)
        {
            
            Root roots = JsonConvert.DeserializeObject<Root>(jsonInput);

            IDictionary<string, double> result = new Dictionary<string, double>();
            foreach( var root in roots.advisors)
            {
                if (!result.ContainsKey(root.name))
                {
                    result.Add(root.name, 0);
                }
            }
            
            foreach (var adv in roots.advisors )
            {
                double res=0;
               foreach (var acc in roots.accounts)
                {
                     
                    if(acc.advisor == adv.name)
                    {
                        res +=acc.presentValue* getcommission(adv.level) * getbps(acc.presentValue);
                    }
                    res = Math.Round(res, 2);
                }
                if (result.ContainsKey(adv.name))
                {
                    result[adv.name] = res;
                }
            }

            return result;

        }

        public int getbps(int value)
        {
            int bps;
            if (value < 50000) bps = 5;
            else if (value < 100000 && value >= 50000) bps = 6;
            else bps = 7;
            return bps;
        }

        public double getcommission(string value)
        {
            double com;
            if (value == "Senior") com = 0.0001;
            else if (value == "Experienced") com = 0.00005;
            else com = 0.000025;
            return com;
        }
        public class Account
        {
            public string advisor { get; set; }
            public int presentValue { get; set; }
        }

        public class Advisor
        {
            public string name { get; set; }
            public string level { get; set; }
        }

        public class Root
        {
            public List<Advisor> advisors { get; set; }
            public List<Account> accounts { get; set; }
        }


    }
}
