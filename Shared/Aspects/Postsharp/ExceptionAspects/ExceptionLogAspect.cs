﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
using Shared.CrossCuttingConcerns.Logging.Log4Net;

namespace Shared.Aspects.Postsharp.ExceptionAspects
{
    [Serializable]
    public class ExceptionLogAspect : OnExceptionAspect
    {
        [NonSerialized] private LoggerService _loggerService;
        private Type _loggerType;

        public ExceptionLogAspect(Type loggerType = null)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType!=null)
            {
                if (_loggerType.BaseType!=typeof(LoggerService))
                {
                    throw new Exception("Wrong Logger Type");
                }

                _loggerService = (LoggerService) Activator.CreateInstance(_loggerType);
            }
            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            _loggerService?.Error(args.Exception);
        }
    }
}
