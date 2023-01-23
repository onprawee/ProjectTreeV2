using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isFollowing;

    public float followSpeed;

    public Transform followTarget;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!isFollowing)
            {
                PlayerPressButton theplayer = other.GetComponent<PlayerPressButton>();

                followTarget = theplayer.keyFollowPoint;

                isFollowing = true;

                for (int i = 0; i < theplayer.followingKey.Length; i++)
                {
                    if (theplayer.followingKey[i] == null)
                    {
                        theplayer.followingKey[i] = this;
                        break;
                    }
                }

            }
        }
    }
}
