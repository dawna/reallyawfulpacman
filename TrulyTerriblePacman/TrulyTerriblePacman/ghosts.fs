(*need to write pathFromTo*)
(* Binky chases pacman directly*)
(* pacmanPos and BlinkyPos are of the form (x,y) *)
let blinkyMove (pacmanPos:int*int) (blinkyPos:int*int) :int*int = 
  let pathToPacman = pathFromTo blinkyPos pacmanPos 
 in
  match pathToPacman with
  | Some (hd::tl) -> hd
  | _ -> Failure "Blinky's pathfind failed"
;;
(*Pinky attempts to cut off pacman by targeting 4 nodes infront of him *)
(*   pacmanDir is of the form (x,y) where x,y E { "+","-","_"} . _ signifies
     no direction in that axis, and + , - signify poitive or negative in that 
     axis *)
let pinkyMove (pacmanPos:int*int) (pacmanDir:string*string) (pinkyPos:int*int) :int*int =
  
  let targetNode = match pacmanPos with 
                   | (x,y) -> match pacmanDir with
                              | ("+",_)-> ((x+4),y)
			      | ("-",_)-> ((x-4),y) 
                              | (_,"+")-> (x,(y+4))
                              | (_,"-")-> (x,(y-4))
                              | (_,_) -> Failure "invalid pacmanDir given to pinky"
  in 
  let pathToPacman = pathFromTo pinkyPos targetNode
  in
  match pathToPacman with
  | Some (hd::tl) -> hd
  | _ -> Failure "Pinky's pathfind failed"
;;