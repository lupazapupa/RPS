namespace RPS {
    internal class Program {
        static void Main(string[] args) {
            try {
                Game game = new Game();
                Console.Write("Добро пожаловать в игру \"Камень Ножницы Бумага\"!");
                game.Round();

                Console.WriteLine("Спасибо за игру");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }

}