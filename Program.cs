namespace RPS {
    internal class Program {
        static void Main(string[] args) {
            try {
                Game game = new Game();
                Console.Write("Добро пожаловать в игру \"Камень Ножницы Бумага\"!\nВведите необходимое количество очков для победы: ");
                game.FinalScore = Convert.ToUInt32(Console.ReadLine());
                game.Round();
                Console.WriteLine("Спасибо за игру");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }

}