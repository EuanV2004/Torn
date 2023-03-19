using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Torn.Office
{
    public abstract class OfficePiece : MonoBehaviour
    {
        public GameManager gm;

        [SerializeField]
        bool isSelected = false;

        // Update is called once per frame
        void Update()
        {
            ChangeSelectedState();
        }

        protected void ChangeSelectedState()
        {
            if (isSelected)
            {
                GetComponentInChildren<SpriteRenderer>().color = new Color(0f, 168f, 255f);
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().color = Color.blue;
            }
        }

        protected void Select()
        {
            isSelected = true;
        }

        public void UnSelect()
        {
            isSelected = false;
        }

        // Make the piece clicked on as the selected piece
        void OnMouseDown()
        {
            if (gm.GetSelectedPiece() != null)
            {
                gm.GetSelectedPiece().GetComponentInParent<OfficePiece>().UnSelect();
            }

            gm.SetSelectedPiece(gameObject);

            Select();
        }
    }
}
