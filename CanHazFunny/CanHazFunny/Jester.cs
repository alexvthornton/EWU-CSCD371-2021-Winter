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

            string joke = this.jokeService.GetJoke();
            while(joke.Contains("Chuck Norris")){
                joke = this.jokeService.GetJoke();
            }
            this.jokeOutput.printJoke(joke);
        }

    }
}
