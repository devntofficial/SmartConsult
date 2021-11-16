namespace SmartConsult.Api
{
    public class MyCustomInnerConfig
    {
        public string innerKey1 { get; set; }
    }
    public class MyCustomConfig
    {

        public string key1 { get; set; }
        public string key2 { get; set; }
        public MyCustomInnerConfig key3 { get; set; }
    }

}
