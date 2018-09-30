using System;
using System.Collections;
using System.Collections.Generic;


namespace DesignMode
{
    public class StateManager : Singleton<StateManager>
    {
        private BaseState curState;
        private Dictionary<string, BaseState> stateList = new Dictionary<string, BaseState>();

        public void Register(BaseState state, string name)
        {
            stateList[name] = state;
        }

        public void ChangeState(string state)
        {
            BaseState baseState;
            stateList.TryGetValue(state, out baseState);
            if (curState != null)
            {
                if (!curState.CheckLeave())
                {
                    Console.WriteLine("curstate check leave error! curstate: " + curState.name + " newstate: " + state);
                    return;
                }    
            }
            if (!baseState.CheckEnter())
            {
                Console.WriteLine("new state check enter error! curstate: " + curState.name + " newstate: " + state);
                return;
            }

            curState = baseState;
            if (curState != null)
                curState.OnLeave();
            baseState.OnEnter();
        }

        public void OnUpdate()
        {
            if (curState != null)
                curState.OnUpdate();
        }

        public BaseState GetCurState()
        {
            return curState;
        }
    }

    public class BaseState
    {
        protected StateManager stateMgr;
        public string name;
        public virtual void OnUpdate() { }
        public virtual void OnEnter() { }
        public virtual void OnLeave() { }
        public virtual bool CheckEnter() { return true; }
        public virtual bool CheckLeave() { return true; }

        public BaseState(StateManager mgr, string name)
        {
            this.stateMgr = mgr;
            this.name = name;
        }
        public bool CheckPreState(ref string[] limitStates)
        {
            //判断能否从当前状态进入新状态
            BaseState preState = stateMgr.GetCurState();
            foreach (string limitState in limitStates)
            {
                if (preState != null && limitState == preState.name)
                    return false;
            }
            return true;
        }
    }

    public class IdleState : BaseState
    {
        //不能从limitstate切换到该状态
        private string[] limitStates = new string[]
        {
            "DeadState",
            "State1",
            "State2",
        };

        public IdleState(StateManager mgr, string name) : base(mgr, name) { }
        public override bool CheckEnter()
        {
            //检查前置
            return CheckPreState(ref limitStates);
        }
        public override void OnUpdate()
        {
            Console.WriteLine("this is idle");
            stateMgr.ChangeState("DeadState");
        }
    }

    public class DeadState : BaseState
    {
        private string[] limitStates = new string[]
        {
            "State1",
            "State2",
        };

        public DeadState(StateManager mgr, string name) : base(mgr, name) { }
        public override bool CheckEnter()
        {
            return CheckPreState(ref limitStates);
        }

        public override void OnUpdate()
        {
            Console.WriteLine("this is dead");
            //切换将会失败,前置检查失败
            stateMgr.ChangeState("IdleState");
        }
    }

    /* 
     * 状态模式:将不同行为划分到不同状态，状态变化引起行为变化
     * 各个状态负责具体行为，及状态切换时的前后置等条件的检测
     */
    public class StatePattern
    {
        /*
        static void Main(string[] args)
        {
            StateManager stateMgr = StateManager.GetInstance_nogc();
            stateMgr.Register(new IdleState(stateMgr, "IdleState"), "IdleState");
            stateMgr.Register(new DeadState(stateMgr, "DeadState"), "DeadState");
            stateMgr.ChangeState("IdleState");
            while(true)
            {
                stateMgr.OnUpdate();
            }
            //Console.ReadLine();
        }
        */
    }


}
