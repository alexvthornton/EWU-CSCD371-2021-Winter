namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            JokeService js = new ();
            System.Console.WriteLine(js.GetJoke());

            //Feel free to use your own setup here - this is just provided as an example
            //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
        }
    }
}
