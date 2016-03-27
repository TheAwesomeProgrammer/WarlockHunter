
public class ZapShot : Shot
{
    protected override void Start()
    {
        base.Start();
        DamagingTags.Clear();
        DamagingTags.Add("Player");
    }
}
