﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OzarkRecovery.Infrastructure.Infrastructure
{
	public class BootStrapper
	{
		public static void RegisterIoC(){
			ObjectFactory.Initialize(x => { 
			
			
			});
		}
	}
}
