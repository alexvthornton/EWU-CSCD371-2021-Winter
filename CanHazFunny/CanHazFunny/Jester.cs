namespace CanHazFunny
{
    public class Jester
    {
        private IJokeService jokeService;
        private IJokeOutput jokeOutput;
        public Jester(IJokeService jokeService, IJokeOutput jokeOutput)
        {

            //do null check
            this.jokeService = jokeService;
            this.jokeOutput = jokeOutput;
        }

        public void TellJoke(){

            string joke = jokeService.GetJoke();
            while(joke.Contains("Chuck Norris")){
                joke = jokeService.GetJoke();
            }

            JokeOutput.printJoke(joke);
        }

    }
}
