using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookbookMenu : MonoBehaviour
{

    public List<SlotSO> slots;

    private List<RecipieSO> recipies;

    public DisplayInteraction di;

    private int pages;

    private int currentPage;

    private RecipieSO r;

    // Start is called before the first frame update
    void Start()
    {
        recipies = di.recipies;
        pages = recipies.Count / 8;
        currentPage = 1;

        if (pages > 1) {

            for (int i = 0; i < 8; i++) {
                r = recipies[i];

                if (i == 0) {

                    


                }

            }

        } else {

            for (int i = 0; i < recipies.Count; i++) {

            }

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next() {

	}

    public void prev() {

    }

}
