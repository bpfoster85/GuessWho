namespace GuessWho{
    public class Prediction{
        public string TagName { get; set; }
        public string Probability { get; set; }

        public Prediction()
        {
            
        }
        public Prediction(string tName, float prob)
        {
            this.TagName = tName;
            this.Probability = (prob * 100).ToString("##.##") + "%";
            
        }
    }
}