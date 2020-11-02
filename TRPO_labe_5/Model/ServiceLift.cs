using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_5.Annotations;
using TRPO_labe_5.States;

namespace TRPO_labe_5.Model
{
    class ServiceLift
    {
        private int _currentCarrying = 0;
        private IState _currentState;
        public int CurrentFloor { get; set; }
        public int Carrying { get; set; }
        public int ProbabilityOfPowerOutage { get; set; }

        public IState State
        {
            get => _currentState;
            private set
            {
                _currentState = value;
                _currentState.DoAction();
            }
        }

        public ServiceLift()
        {
            State = new Rest();
        }

        public void CallOnFloor(int floor)
        {
            var rnd = new Random();
            if (State is Overload)
            {
                Console.WriteLine("Не получается поехать!");
            }
            else
            {
                int randomInt = rnd.Next(0, 101);
                if (randomInt <= ProbabilityOfPowerOutage)
                    State = new NoPower();
                else
                {
                    State = new Movement();
                    CurrentFloor = floor;
                }
            }

        }

        public void Load(int weight)
        {
            _currentCarrying += weight;
            if (_currentCarrying > Carrying)
                State = new Overload();
        }

        public void Unload(int weight)
        {
            if (_currentCarrying - weight < 0) throw new Exception("Как лифт может сбросить вес, которого нет?!");
            _currentCarrying -= weight;
            State = new Rest();
        }

        public void RestorePowerSupply()
        {
            if (State is NoPower)
                State = new Rest();
        }
    }
}
