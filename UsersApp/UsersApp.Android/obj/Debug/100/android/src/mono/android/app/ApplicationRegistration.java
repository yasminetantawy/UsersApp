package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("UsersApp.Droid.MainApplication, UsersApp.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64fb229261e835fbad.MainApplication.class, crc64fb229261e835fbad.MainApplication.__md_methods);
		
	}
}
