package md50eabe674bbdb78169f3ea9c3b833d307;


public class EvidencesListActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Hack_Home.EvidencesListActivity, Hack@Home, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", EvidencesListActivity.class, __md_methods);
	}


	public EvidencesListActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EvidencesListActivity.class)
			mono.android.TypeManager.Activate ("Hack_Home.EvidencesListActivity, Hack@Home, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
