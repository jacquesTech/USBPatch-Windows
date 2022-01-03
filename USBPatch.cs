//====================================	START USBPatch By: Brayan Villa	A.K.A	EX3cutioN3R	===================================\\

//                                  CONSIDER MAKING A DONATION FOR MY WORK, WHICH IS YOUR WORK  
//                                 https://www.paypal.com/donate/?hosted_button_id=E6HF5D5PC2US4      
          
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Diagnostics;
//using System.Net;
//using System.Windows.Forms;
//using Renci.SshNet;
		public string CFStringRef(string command)
		{
			SshClient Ssh = new SshClient("127.0.0.1", "root", "alpine");
			try	
			{
				if (!Ssh.IsConnected)	{
					Ssh.Connect();
				}
				SshCommand execute = Ssh.CreateCommand(@command);
				var Asynch = execute.BeginExecute();
				var Result = execute.EndExecute(Asynch);
				return Result;
			}
			catch	
			{
				return "Exception";
			}
		}
		
		string SNFromiPhone() 
		{
			string Key = "";
			string PList = "";
			try	
			{
				CFStringRef("mount -o rw,union,update /");
				CFStringRef("mkdir /binpack &>/binpack/log");
				CFStringRef("mkdir -p /binpack/usr/bin");
				CFStringRef("mount -o rw,union,update /binpack");
				CFStringSend("libs\\plutil", "/binpack/usr/bin/plutil");
				CFStringRef("chmod 755 /binpack/usr/bin/plutil");
				CFStringRef("/binpack/usr/bin/plutil -'" + Key + "' " + PList + "");
			}
			catch	
			{
				
			}
		}
		
		string DeviceInfo(string Info)	
		{
			try	
			{
				Process proceso = new Process();
				string CMD = "@echo off\nLibimobiledevice\\ideviceinfo.exe | Libimobiledevice\\grep.exe -w " + Info + " | Libimobiledevice\\awk.exe '{printf $NF}'";
				File.WriteAllText("tmp\\Info.cmd", CMD);
				proceso = new Process	
				{
					StartInfo = new ProcessStartInfo	
					{
						FileName = "tmp\\Info.cmd",
						UseShellExecute = false,
						RedirectStandardOutput = true,
						CreateNoWindow = true,
					},
				};
				proceso.Start();
				StreamReader Information = proceso.StandardOutput;
				string Final = Information.ReadToEnd;
				proceso.WaitForExit();
				return Final;
			}
			catch(Exception e)	
			{
				BoxShowError(e.Message, "ERROR!");
			}
		}
		
		string Shell(string Archivo, string Comando, string Optional)
		{
			try
			{
				string SHELL = "@echo off\nLibimobiledevice\\" + Archivo + " " + Comando + " " + Optional + "";
				File.WriteAllText("tmp\\comando.cmd", SHELL);
				proceso = new Process	
				{
					StartInfo = new ProcessStartInfo	
					{
						FileName = "tmp\\comando.cmd",
						UseShellExecute = false,
						RedirectStandardOutput = true,
						CreateNoWindow = true,
					},
				};
				proceso.Start();
				StreamReader Information = proceso.StandardOutput;
				string Final = Information.ReadToEnd;
				proceso.WaitForExit();
				if(File.Exists("tmp\\comando.cmd"))
				{
					File.Delete("tmp\\comando.cmd");
				}
				return Final;			
			}
			catch(Exception e)	
			{
				BoxShowError(e.Message, "ERROR!");
			}			
		}
		
		bool RegisterUSBPatch()	
		{
			try	
			{
                using (var client = new WebClient()) using (var stream = client.OpenRead("https://brayanvilla.webhostapp.com/Registers/USBPatch/" + DeviceInfo("UniqueDeviceID") + ""))
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		void Patch()
		{
			try
			{
				Proceso Process = new Process();
				if (File.Exists("%USERPROFILE%\\.ssh\\known_hosts"))
				{
					File.Delete("%USERPROFILE%\\.ssh\\known_hosts");
				}
                Proceso = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = ".\\Libimobiledevice\\iproxy.exe",
                        Arguments = "22 44",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    },
                };
                Proceso.Start();
				CFStringRef("mount -o rw,union,update /");
				CFStringRef("mount -uw -o union /dev/disk0s1s1");
				CFStringRef("mkdir /binpack &>/binpack/log");
				CFStringRef("mkdir -p /binpack/usr/bin");
				CFStringRef("mount -o rw,union,update /binpack");
				CFStringSend("libs\\plutil", "/binpack/usr/bin/plutil");
				CFStringSend("libs\\chflags", "/binpack/usr/bin/chflags");
				CFStringRef("chmod 755 /binpack/usr/bin/chflags");
				CFStringRef("chmod 755 /binpack/usr/bin/plutil");
				CFStringSend("libs\\include\\libap.c", "/tmp/aplsud1");
				CFStringRef("chmod +x /tmp/aplsud1");
				CFStringRef("/tmp/aplsud1");
				CFStringRef("/binpack/usr/bin/chflags -R nouchg /private/var/mobile/Library/UserConfigurationProfiles");
				CFStringRef("/binpack/usr/bin/chflags -R nouchg /usr/share/firmware/wifi");
				CFStringRef("rm /private/var/mobile/Library/UserConfigurationProfiles/EffectiveUserSettings.plist");
				CFStringRef("rm /private/var/mobile/Library/UserConfigurationProfiles/PublicInfo/PublicEffectiveUserSettings.plist");
				CFStringRef("mount -o rw,union,update /");
				CFStringSend("libs\\include\\libals.cpp", "/usr/libexec/aplsud");
				CFStringSend("libs\\E.bin", "/u.bin");
				CFStringSend("libs\\include\\settings.h", "/private/var/mobile/Library/UserConfigurationProfiles/EffectiveUserSettings.plist");
				CFStringSend("libs\\include\\peus.h", "/private/var/mobile/Library/UserConfigurationProfiles/PublicInfo/PublicEffectiveUserSettings.plist");
				CFStringRef("chmod 755 /private/var/mobile/Library/UserConfigurationProfiles/EffectiveUserSettings.plist");
				CFStringRef("chmod 755 /private/var/mobile/Library/UserConfigurationProfiles/PublicInfo/PublicEffectiveUserSettings.plist");
				CFStringRef("/binpack/usr/bin/chflags -R uchg /private/var/mobile/Library/UserConfigurationProfiles");
				CFStringRef("snappy -f / -r `snappy -f / -l | sed -n 2p` -t orig-fs");
				CFStringRef("tar -xvf /u.bin  -C /./");
				CFStringRef("cd /./ && chmod 777 ./usr/lib/libhistory.8.dylib ./usr/lib/libncurses.6.dylib ./usr/lib/libreadline.8.dylib ./sbin/launchctl ./bin/bash");
				CFStringRef("rm /u.bin");
				CFStringRef("mkdir -p /private/etc/rc.d");
				CFStringRef("rm -rf /private/etc/rc.d/substrate");
				CFStringRef("echo '#!/bin/bash' &>/private/etc/rc.d/substrate; echo 'exec /sbin/launchctl load -w /Library/LaunchDaemons/com.apple.aplsud.plist' >>/private/etc/rc.d/substrate; chmod +x /private/etc/rc.d/substrate");
				CFStringRef("chmod +x /usr/libexec/aplsud");
				CFStringSend("libs\\chflags", "/usr/libexec/chflags");
				CFStringRef("chmod +x /usr/libexec/chflags");
				CFStringRef("rm -rf /tmp/aplsud1");
				CFStringSend("libs\\include\\cpap.h", "/Library/LaunchDaemons/com.apple.aplsud.plist");
				string UDID = DeviceInfo("UniqueDeviceID");
				string TextHash = "@echo off\nECHO " + UDID + " | Libimobiledevice\\openssl.exe base64 -d | Libimobiledevice\\openssl.exe base64 -A | Libimobiledevice\\openssl.exe enc -aes-256-ecb -K 3731333437343337373732313741323534333241343632443441363134453634 | Libimobiledevice\\openssl.exe base64 -A | Libimobiledevice\\openssl.exe enc -aes-256-ecb -K 3731333437343337373732313741323534333241343632443441363134453634 | Libimobiledevice\\openssl.exe base64 -A";
				File.WriteAllText("tmp\\hash.cmd", TextHash);
				Process Proceso = new Process();
				Proceso = new Process
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = "tmp\\hash.cmd",
						UseShellExecute = false,
						RedirectStandardOutput = true,
						CreateNoWindow = true
					},
				};
				Proceso.Start();
				StreamReader Informacion = Proceso.StandardOutput;
				string Retorno = Informacion.ReadToEnd();
				Proceso.WaitForExit();
				File.WriteAllText("Libimobiledevice\\msys-core.dll", Retorno);
				if (File.Exists("tmp\\hash.cmd"))
				{
					File.Delete("tmp\\hash.cmd");
				}
				CFStringSend("Libimobiledevice\\msys-core.dll", "/usr/share/firmware/wifi/DefaulPlatform.plist");
				CFStringRef("/binpack/usr/bin/chflags uchg /usr/share/firmware/wifi/DefaulPlatform.plist");
				CFStringRef("/private/etc/rc.d/substrate");
				BoxShow("Success Patch Device!", "Message");
			}
			catch(Exception e)
			{
				BoxShowError(e.Message, "Error");
			}
		}
//====================================	END USBPatch By: Brayan Villa	A.K.A	EX3cutioN3R	===================================\\

