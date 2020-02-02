


class Bolder : bullet
{
	
	private void OnImpact() override
	{
			creatDamageZone(transform.position, explosionRadius);
            Destroy(gameObject, 0.24f);
            isMoving = false;
	}
	
	private void DisplayExplosion(??? position) override
	{
		?instanciate? m_ExplosionSprite(position);
	}
	
	
}

class Bomb : Bolder
{
}

class FireBomb : Bomb
{
	public ??? m_FireSprite;
	public array<???> m_TowersToBurn;
	
	public float m_FireDuration;
	public float m_FireDamage;
	
	private void OnImpact() override
	{
		DisplayExplosion(this.position);
		//TakeSamageOverTime
	}
}

class SuperBomb : FireBomb
{
	public float m_DistanceBetweenExplosions;
	public float m_TimeBetweenExplosions;
	
	private ??? m_Target2;
	private ??? m_Target3;
	
	private bool m_HasLanded = false;
	private Time m_LandedStartTime;
	
	void Init() override
	{
		FireBomb::Init();
		vector3 direction = m_Target - m_Origin;
		vector3 stepVector = direction * m_DistanceBetweenExplosions;
		m_Target2 = m_Target + stepVector;
		m_Target3 = m_Target2 + stepVector;
	}
	
	void Update() override
	{
		
	}
	
	private void OnImpact() override
	{
		FireBomb::OnImpact();
		if(!m_HasLanded)
		{		
			m_LandedStartTime = Time.time();
			m_HasLanded = true; 
		}			
	}
}
