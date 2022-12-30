class Game {
    private Random PCTurn = new();

    private uint _playerPoints = 0;
    private uint _pcPoints = 0;
    private uint _roundCount = 1;
    private uint _playerTurn;
    private uint _pcTurn;
    private uint _finalScore;

    public uint FinalScore {
        set {
            _finalScore = value > 0 ? value : 1;
            Console.WriteLine($"В данной игре необходимо победить {_finalScore} раз(а)");
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

    private string Result(uint player, uint pc) {
        string[,] winTable = { { "D", "W", "L" }, { "L", "D", "W" }, { "W", "L", "D" } };
        return winTable[player, pc];
    }

    public void Round() {
        while (true) {
            Console.WriteLine($"Раунд {_roundCount}:");
            while (true) {
                Console.WriteLine("Сделайте выбор: 1 - Камень, 2 -  Ножницы, 3 - Бумага, 4 - Выход");
                _playerTurn = Convert.ToUInt32(Console.ReadLine());
                if (_playerTurn < 0 || _playerTurn > 4) {
                    Console.WriteLine("Неверная комманда, попробуйте снова");
                } else {
                    break;
                }
            }
            if (_playerTurn == 4) { break; }
            ChoiceMSG("Игрок", _playerTurn);
            _pcTurn = Convert.ToUInt32(PCTurn.Next(1, 3));
            ChoiceMSG("Компьютер", _pcTurn);
            string result = Result(_playerTurn, _pcTurn);
            switch (result) {
                case "D":
                    Console.WriteLine("В этом раунде ничья");
                    break;
                case "L":
                    Console.WriteLine("Вы проиграли этот раунд");
                    _pcPoints++;
                    break;
                case "W":
                    Console.WriteLine("Вы выиграли этот раунд");
                    _playerPoints++;
                    break;
            }
            if (_playerPoints == _finalScore) {
                Console.WriteLine($"Вы выиграли со счетом [ {_playerPoints} : {_pcPoints} ]. Поздравляю!");
                break;
            } else if (_pcPoints == _finalScore) {
                Console.WriteLine($"Вы проиграли со счетом [ {_playerPoints} : {_pcPoints} ]. Успехов в следующий раз!");
                break;
            } else {
                Console.WriteLine($"Текущий счет [ {_playerPoints}  :  {_pcPoints} ]");
            }
            _roundCount++;
        }
    }
}