class Game {
    private Random PCTurn = new();

    private uint _playerStrike = 0;
    private bool _strikeBreak = false;
    private uint _roundCount = 1;
    private uint _playerTurn;
    private uint _pcTurn;

    public uint WinStrike {
        get {
            return _playerStrike;
        }
    }


    private void ChoiceMSG(string name, uint choice) {
        switch (choice) {
            case 1:
                Console.WriteLine($"{name} выбрал камень");
                break;
            case 2:
                Console.WriteLine($"{name} выбрал ножницы");
                break;
            case 3:
                Console.WriteLine($"{name} выбрал бумагу");
                break;
        }
    }

    private  void WhoWin(uint player, uint pc) {
        string[,] winTable = { { "D", "W", "L" }, { "L", "D", "W" }, { "W", "L", "D" } };
        switch (winTable[player, pc]) {
            case "D":
                Console.WriteLine("В этом раунде ничья");
                break;
            case "L":
                Console.WriteLine("Вы проиграли этот раунд");
                _strikeBreak = true;
                break;
            case "W":
                Console.WriteLine("Вы выиграли этот раунд");
                _playerStrike++;
                break;
        }
    }

    private uint ParsingCMD () {
        uint cmd;
        while (true) {
            Console.WriteLine("Сделайте выбор: 1 - Камень, 2 -  Ножницы, 3 - Бумага, 4 - Выход");
            cmd = Convert.ToUInt32(Console.ReadLine());
            if (cmd < 0 || cmd > 4) {
                Console.WriteLine("Неверная комманда, попробуйте снова");
            } else {
                break;
            }
        }
        if (_playerTurn == 4) { _strikeBreak = true; }
        return cmd;
    }

    public void Round() {
        while (true) {
            Console.WriteLine($"Раунд {_roundCount}:");
            _playerTurn = ParsingCMD();
            ChoiceMSG("Игрок", _playerTurn);
            _pcTurn = Convert.ToUInt32(PCTurn.Next(1, 3));
            ChoiceMSG("Компьютер", _pcTurn);
            WhoWin(_playerTurn, _pcTurn);
            if (_strikeBreak) {
                _strikeBreak = false;
                Console.WriteLine($"Вы завершили игру со счетом -- {_playerStrike}. Поздравляю!");

                break;
            } else {
                Console.WriteLine($"Текущий счет -- {_playerStrike}");
            }
            _roundCount++;
        }
    }
}