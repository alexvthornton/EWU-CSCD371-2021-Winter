namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            Jester jester = new Jester(new JokeService(), new JokeOutput());
            jester.TellJoke();
            //Feel free to use your own setup here - this is just provided as an example
            //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
        }
    }
}
