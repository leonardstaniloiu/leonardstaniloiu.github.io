
package org.example;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.SerializationFeature;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;

import java.io.File;
import java.io.IOException;
import java.util.*;
import java.util.stream.Collectors;


public class Main {

    public static void main(String[] args) throws IOException {
      ObjectMapper objectMapper = new ObjectMapper();
      TypeReference<HashMap<Integer,Carte>> typeReference = new TypeReference<>() {};
      Map<Integer, Carte> colectie = objectMapper.readValue(new File("D:\\lucru_java_intellij\\Lab7\\src\\main\\resources\\carti.json"),typeReference);
        colectie.forEach((cheie, valoare)-> System.out.println(cheie + "  " + valoare.toString()));
        colectie.remove(6);
        System.out.println("Lista dupa stergerea cartii cu id 6: ");
        colectie.forEach((cheie, valoare)-> System.out.println(cheie + "  " + valoare.toString()));

        colectie.putIfAbsent(6,new Carte("Povestea lui Harap-Alb","Ion Creanga",1881));
        System.out.println("Lista dupa adaugare cheie noua: ");
        colectie.forEach((cheie, valoare)-> System.out.println(cheie + "  " + valoare.toString()));

        objectMapper.writeValue(new File("D:\\lucru_java_intellij\\Lab7\\src\\main\\resources\\carti.json"), colectie);
        Set<Carte> colectieNoua = colectie.values().stream()
                .filter((carte -> carte.autorul().equalsIgnoreCase("Yual Noah Harari")))
                .collect(Collectors.toSet());
        colectieNoua.forEach(System.out::println);


      System.out.println("Colectia sortata dupa titlu: \n\n");
        Set<Carte> colectieSortata = colectie.values().stream()
                .sorted(Comparator.comparing(Carte::titlul))
                .collect(Collectors.toCollection(LinkedHashSet::new));
        colectieSortata.forEach(System.out::println);





    }
}